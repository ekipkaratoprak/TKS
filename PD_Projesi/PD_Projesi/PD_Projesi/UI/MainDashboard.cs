using System;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;

namespace PD_Projesi.UI
{
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            this.Size = new Size(866, 224);
            this.Top = 300;
            pnlDetailes.Visible = false;
            lblLoading.Visible = false;
        }

        public static String path = null ;

        static string text ;
        //static degiskeni ile tum metni metodu sadece tek bir sefer cagirarak bulunur

        static string[] pages;
        //static degiskeni ile ayrilastirilmis sayfalar metodu sadece tek bir sefer cagirarak bulunur

        static String extractText(string path)
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(path))
            {
                pages = new string[reader.NumberOfPages];

                StringBuilder page = new StringBuilder();
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    page.Clear();
                    page.Append(PdfTextExtractor.GetTextFromPage(reader, i));

                    text.Append(page.ToString());
                    pages[i - 1] = page.ToString();
                }
            }

            return text.ToString();
        }

        //Edited (Bazı sayfalar özel karekterler ([,],{,...) ile başladığında metodun çökmesine sebep olur)
        static String extractText_PageNumber(String path, int pageNo)
        {
            PdfReader pdfReader = new PdfReader(path);

            ITextExtractionStrategy its = new SimpleTextExtractionStrategy();

            string txt = null;
            try
            {
                txt = PdfTextExtractor.GetTextFromPage(pdfReader, pageNo, its);//sayfa numarasın page bölümüne yaz, sadece o sayfayı okuyor
            }
            catch (NullReferenceException) { Console.WriteLine("Okuma işlemi başarısızdır (Sayfanın içinde özel karekterler var)"); return "0"; }

            string extractedPageNoText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(txt)));

            return extractedPageNoText;
        }

        //New
        //Dökümanın içinde gerçek sayfa 1'in yerini bulmak (Örnek tezin içinde gerçek 1. sayfa 14)
        static int FindTheRealFirstPage()
        {
            int pageNo = 0;
            StringBuilder flag = new StringBuilder(3);
            while (flag.ToString() != "1")
            {
                pageNo++;
                flag.Clear();
                //flag.Append(extractText_PageNumber(path, pageNo).Substring(0,1));
                flag.Append(pages[pageNo].Substring(0, 1));
            }

            return ++pageNo;
        }

        //New
        //Iki anahtar kelime arasinda metin cikartilir
        static string TextBetweenTwoKeyWords(string firstKey, string lastKey)
        {
            int endIndex = text.LastIndexOf(lastKey) - text.IndexOf(firstKey);
            //Içindekiler içindekiler tablosu bulunabileceğinden IndexOf kullanılmış
            return text.Substring(text.IndexOf(firstKey), endIndex);
        }


        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
         {
        {'i', 1},
        {'v', 5},
        {'x', 10},
        {'l', 50},
        {'c', 100},
        {'d', 500},
        {'m', 1000}
         };

        public static int RomanToInteger(string roman)
        {
            int number = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                try
                {
                    if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
                    {
                        number -= RomanMap[roman[i]];
                    }
                    else
                    {
                        number += RomanMap[roman[i]];
                    }
                }

                catch (KeyNotFoundException) { return -1; }
            }
            return number;
        }

        static int realFirstPage;
        static string[] IcindekilerKontrolu()
        {
            //Eski
            //string icindekiler = TextBetweenTwoKeyWords("İÇİNDEKİLER", "ÖZET");

            string icindekiler = String.Empty;
            if (genelKontrol[2] == false)
            {
                wrongsArray.Add("İçindekiler KISMI BULUNMADI!!,İçindekiler");
                return null;
            }

            else
            {
                //genel kontrol metodundaki ana basliklar dizisinin sirasinda gore Icindekiler(2) -> 1.Giris(9)
                for (int i = 3; i <= 9; i++)
                {
                    if (genelKontrol[i] == true)
                    {
                        icindekiler = TextBetweenTwoKeyWords("İÇİNDEKİLER", anaBaslik[i]);
                        break;
                    }
                }
            }

            string[] baslik = icindekiler.Split('\n');
            //baslik dizisi baslangicta satirlari tutar sonra satirlarin her birisi sadece baslik ile degistirilecek
            string[] sayfaNo = new string[baslik.Length - 2];


            //1. ve 2. satir onemsiz oldugundan index 2den baslanir 
            for (int i = 2; i < baslik.Length; i++)
            {
                sayfaNo[i - 2] = baslik[i].Substring(baslik[i].LastIndexOf('.') + 2, baslik[i].Length - baslik[i].LastIndexOf('.') - 3);

                if (char.IsDigit((baslik[i])[0]))
                {
                    string baslikText = baslik[i].Substring(baslik[i].IndexOf(' '), baslik[i].Length - baslik[i].IndexOf(' ')).Trim();
                    baslik[i - 2] = new StringBuilder().Append(baslik[i].Substring(0, baslik[i].IndexOf(' '))).Append(' ').Append(baslikText.Substring(0, baslikText.IndexOf('.'))).ToString().Trim();

                }
                else if (baslik[i].IndexOf('.') != -1)
                {
                    baslik[i - 2] = baslik[i].Substring(0, baslik[i].IndexOf('.')).Trim();
                }
            }

            realFirstPage = FindTheRealFirstPage();

            int baslikIndex = 0;
            List<String> hataDizisi = new List<string>();
            //Hatalar bu sekilde eklenecek : Hata sayfa , icindekiler
            foreach (string Num in sayfaNo)
            {
                if (Char.IsDigit(Num[0]))
                {
                    if (!pages[Convert.ToInt32(Num) + realFirstPage - 2].Contains(baslik[baslikIndex]))
                    {
                        //Console.WriteLine(baslik[baslikIndex] + " belirlenen sayfa " + (Convert.ToInt32(Num)).ToString()
                        //    + " (" + (Convert.ToInt32(Num) + realFirstPage - 1).ToString() + ") " + " icinde bulunmadi.");

                        hataDizisi.Add(baslik[baslikIndex] + " belirlenen sayfa " + (Convert.ToInt32(Num)).ToString()
                            + " (" + (Convert.ToInt32(Num) + realFirstPage - 1).ToString() + ") " + " icinde bulunmadi." + ",İçindekiler");
                    }
                    baslikIndex++;
                }

                else
                {
                    try
                    {
                        if (!pages[RomanToInteger(Num)].Contains(baslik[baslikIndex]))
                        {
                            //Console.WriteLine(baslik[baslikIndex] + " belirlenen sayfa " + (RomanToInteger(Num) + 1).ToString() + " icinde bulunmadi.");
                            hataDizisi.Add(baslik[baslikIndex] + " belirlenen sayfa " + (RomanToInteger(Num) + 1).ToString() + " icinde bulunmadi." + ",İçindekiler");
                        }
                        baslikIndex++;
                    }
                    catch (IndexOutOfRangeException) { break; }
                }
            }

            return hataDizisi.ToArray();
        }

        static void KelimeKontrol()
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("PD_Projesi.Words_DB.kelimeler.txt"));

                string kelimekontrol = "";
                int counter = 0;

                string line = "";

                HashSet<String> dizi2 = new HashSet<String>();
                while ((line = reader.ReadLine()) != null)

                {
                    Regex rx = new Regex(" " + line + " ", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    Match match = rx.Match(text);


                    while (match.Success)
                    {
                        dizi2.Add(match.Value);
                        match = match.NextMatch();
                    }


                    counter++;

                }
                foreach (string s in dizi2)
                {
                     wrongsArray.Add("'" + s + "'" + " KELİMESİ YANLIŞ YAZILMIŞ!" + ",Kelimeler");
                    //kelimekontrol = kelimekontrol + "\n" + "'" + s + "'" + " KELİMESİ YANLIŞ YAZILMIŞ!";
                }
                //Console.WriteLine(kelimekontrol);
            }
            catch (Exception Ex)
            {
                Console.WriteLine("HATA OLUŞTU:" + Ex.Message);

            }
        }

        static void TirnakKontrol(MainDashboard md)
        {
            try
            {
                string asd = "“";
                Regex rx = new Regex(@asd, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match match = rx.Match(text);

                List<String> dizi2 = new List<String>();
                while (match.Success)
                {
                    dizi2.Add(match.Value);
                    match = match.NextMatch();
                }

                if (dizi2.Count > 0)
                {
                    md.lblDurumTirnak.Text = "(“) " + " ifadesi metinde " + (dizi2.Count) * 2 + " defa geçiyor.";
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("HATA OLUŞTU:" + Ex.Message);

            }

        }

        static bool [] genelKontrol = new bool[15];
        static string[] anaBaslik;
        static void GenelKontrol(MainDashboard md)
        {
            #region Old Method
            //bool flag = true;

            //string genelkontrol = "";
            //string[] kontrolindexof = { "BEYAN", "ÖNSÖZ", "İÇİNDEKİLER" };
            //for (int i = 0; i < kontrolindexof.Length; i++)
            //{
            //    if (text.IndexOf(kontrolindexof[i]) == -1)
            //    {
            //        genelkontrol = "\n" + genelkontrol + " " + kontrolindexof[i] + " EKSİK!\n";
            //        flag = false;
            //    }
            //}

            //string[] kontrollastindex = { "ÖZET", "ABSTRACT", "ŞEKİLLER LİSTESİ", "TABLOLAR LİSTESİ", "EKLER LİSTESİ", "SİMGELER VE KISALTMALAR", "1. GİRİŞ", "SONUÇLAR", "ÖNERİLER", "KAYNAKLAR", "EKLER", "ÖZGEÇMİŞ" };
            //for (int i = 0; i < kontrollastindex.Length; i++)
            //{
            //    if (text.IndexOf(kontrollastindex[i]) == -1)
            //    {
            //        genelkontrol = genelkontrol + " " + kontrollastindex[i] + " EKSİK!\n";
            //        flag = false;
            //    }
            //}

            //if (flag == false)
            //{
            //    MessageBox.Show("Tez formatı uygun değildir.\n" + genelkontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    path = null;
            //    md.lblLocation.Text = "//Lütfen kontrol etmek istediğniz tezin PDF dosyası ekleyiniz.";
            //    md.lblLocation.ForeColor = Color.DarkGray;
            //    text = null;
            //}
            #endregion
            //Commented

            anaBaslik = new string[] { "BEYAN \n", "ÖNSÖZ \n", "İÇİNDEKİLER \n", "ÖZET \n", "ABSTRACT \n", "ŞEKİLLER LİSTESİ \n",
                                                "TABLOLAR LİSTESİ \n", "EKLER LİSTESİ \n", "SİMGELER VE KISALTMALAR \n", "1. GİRİŞ \n",
                                                "SONUÇLAR \n", "ÖNERİLER \n", "KAYNAKLAR \n", "EKLER \n", "ÖZGEÇMİŞ \n" };
            
            for (int i = 0; i < anaBaslik.Length; i++)
            {
                if (i < 3)
                {
                    if (text.IndexOf(anaBaslik[i]) != -1)
                    {
                        genelKontrol[i] = true;
                    }
                }

                else
                {
                    if (text.LastIndexOf(anaBaslik[i]) != -1)
                    {
                        genelKontrol[i] = true;
                    }
                }
            }

            StringBuilder eksikKisimlar = new StringBuilder();
            bool eksik = false;
            for(int i = 0; i < genelKontrol.Length; i++)
            {
                if (genelKontrol[i] == false)
                {
                    eksikKisimlar.Append(anaBaslik[i].Trim('\n') + " KISMSI BULUNMADI!! PROGRAM DOĞRU ÇALIŞMAYABİLİR\n");
                    eksik = true;
                }
            }

            if (eksik)
                MessageBox.Show(eksikKisimlar.ToString(), "Eksik Kısımlar Bulundu.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        static bool KaynakcaKontrol()
        {
            try
            {
                // int endIndex = text.LastIndexOf("EKLER") - text.LastIndexOf("KAYNAKLAR") + 1;//c#'ta substring(begınIndex,endIndex) şeklinde değil substrıng(startIndex,length) şeklinde kullanılır.
                //Eski
                //string kaynakca = text.Substring(text.LastIndexOf("KAYNAKLAR"));

                string kaynakca = String.Empty;
                if (genelKontrol[12] == false)
                {
                    wrongsArray.Add("KAYNAKLAR KISMI BULUNMADI!!,Kaynaklar");
                    return false;
                }

                else
                {
                    //genel kontrol metodundaki ana basliklar dizisinin sirasinda gore Icindekiler(2) -> 1.Giris(9)
                    for (int i = 13; i <= 14; i++)
                    {
                        if (genelKontrol[i] == true)
                        {
                            int endIndex = text.LastIndexOf(anaBaslik[i]) - text.LastIndexOf("KAYNAKLAR");
                            kaynakca = text.Substring(text.LastIndexOf("KAYNAKLAR"), endIndex);
                            break;
                        }
                    }
                }

                //SADECE KAYNAKÇA KISMI ATIFLARII BULUYOR
                Regex rx = new Regex(@"\[(\d*)\]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match match = rx.Match(kaynakca);

                List<String> dizi2 = new List<String>();
                while (match.Success)
                {
                    dizi2.Add(match.Value);
                    match = match.NextMatch();
                }


                //10-7 3 0-3
                int endIndexforK = text.Length - text.LastIndexOf("KAYNAKLAR");
                int q = text.Length - endIndexforK;
                string kaynakcaWithout = text.Substring(text.IndexOf("GİRİŞ"), q);


                //METNİ TARIYOR İÇERİDEKİ ATIFLARI KAYNAKÇA HARİÇ BULUYOR
                Regex rxkontrol = new Regex(@"\[\d*\]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match matchkontrol = rxkontrol.Match(kaynakcaWithout);
                HashSet<String> dizikontrol = new HashSet<String>();
                while (matchkontrol.Success)
                {
                    dizikontrol.Add(matchkontrol.Value);
                    matchkontrol = matchkontrol.NextMatch();
                }

                //foreach (string i in dizikontrol)
                //{
                //    Console.WriteLine(i);
                //}
                //METİN İÇİNDEKİ VİRGÜLLÜ ATIFLARI BULUYOR
                Regex rxforcontrolvirgul = new Regex(@"\[\d*,\d*,\d*\]|\[\d*,\d*,\d*,\d*\]|\[\d*,\d*,\d*,\d*\,\d*]|\[\d*,\d*\]|\[\d*,\d*,\d*,\d*,\d*,\d*\]|\[\d*,\s\d*,\s\d*\]|\[\d*,\s\d*\]|\[\d*,\s\d*,\s\d*,\s\d*\]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match matchforcontrolvirgul = rxforcontrolvirgul.Match(kaynakcaWithout);
                HashSet<String> diziforvirgul = new HashSet<string>();

                while (matchforcontrolvirgul.Success)
                {
                    diziforvirgul.Add(matchforcontrolvirgul.Value);
                    matchforcontrolvirgul = matchforcontrolvirgul.NextMatch();
                }

                string[] sArrayvirgul = new string[diziforvirgul.Count];
                diziforvirgul.CopyTo(sArrayvirgul, 0);
                string vrgul = "";

                for (int i = 0; i < sArrayvirgul.Length; i++)
                {
                    sArrayvirgul[i] = sArrayvirgul[i].Replace("–", "-");
                    sArrayvirgul[i] = sArrayvirgul[i].Replace(",", "");
                    sArrayvirgul[i] = sArrayvirgul[i].Replace("[", "");
                    sArrayvirgul[i] = sArrayvirgul[i].Replace("]", "");
                    vrgul = vrgul + sArrayvirgul[i] + " ";
                }
                string[] sArrayvirgul2 = vrgul.Split(' ');
                for (int i = 0; i < sArrayvirgul2.Length; i++)
                {
                    dizikontrol.Add("[" + sArrayvirgul2[i] + "]");
                }
                //METİN İÇİNDEKİ [12-12,45] VEYA [45,12-15] ŞEKLİNDEKİ ATIFLARI BULUYOR
                //
                Regex rxforkar = new Regex(@"\[\d*\–\d*,\s\d*\]|\[\d*\–\d*,\d*\]|\[\d*,\s\d*\–\d*\]|\[\d*,\s\d*\-\d*\]|\[\d*,\d*\–\d*\]|\[\d*\-\d*,\s\d*\]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match matchforkar = rxforkar.Match(kaynakcaWithout);
                HashSet<String> diziforkar = new HashSet<string>();

                while (matchforkar.Success)
                {
                    diziforkar.Add(matchforkar.Value);
                    matchforkar = matchforkar.NextMatch();
                }
                //
                string[] sArraykar = new string[diziforkar.Count];
                diziforkar.CopyTo(sArraykar, 0);
                string kar = "";

                for (int i = 0; i < sArraykar.Length; i++)
                {
                    sArraykar[i] = sArraykar[i].Replace("–", "-");
                    sArraykar[i] = sArraykar[i].Replace("[", " ");
                    sArraykar[i] = sArraykar[i].Replace("]", " ");

                    kar = kar + sArraykar[i] + "";
                }
                string[] sArraykar2 = kar.Split(',');
                // foreach (string i in sArraykar2) { Console.WriteLine(i); }
                //Console.WriteLine(kar);
                //\d*-\d*
                Regex rxforkar1 = new Regex(@"\d*-\d*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match matchforkar1 = rxforkar1.Match(kar);
                List<String> diziforblok = new List<String>();

                while (matchforkar1.Success)
                {
                    diziforblok.Add("[" + matchforkar1.Value + "]");
                    matchforkar1 = matchforkar1.NextMatch();
                }
                string kar2 = "";
                for (int i = 0; i < sArraykar2.Length; i++)
                {
                    if (sArraykar2[i].Contains("-"))
                    {
                        sArraykar2[i] = "";
                    }
                    kar2 = kar2 + sArraykar2[i] + " ";
                }
                kar2 = kar2.Trim();
                Regex rxforkar2 = new Regex(@"\d*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match matchforkar2 = rxforkar2.Match(kar2);
                while (matchforkar2.Success)
                {
                    dizikontrol.Add("[" + matchforkar2.Value + "]");
                    matchforkar2 = matchforkar2.NextMatch();
                }
                //METİN İÇİNDEKİ BLOK ATIFLARI BULUYOR
                Regex rxforcontrolblok = new Regex(@"\[\d*\–\d*\]|\[\d*\-\d*\]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match matchforcontrolblok = rxforcontrolblok.Match(kaynakcaWithout);
                //List<String> diziforblok = new List<String>();

                while (matchforcontrolblok.Success)
                {
                    diziforblok.Add(matchforcontrolblok.Value);
                    matchforcontrolblok = matchforcontrolblok.NextMatch();
                }

                string[] sArray = new string[diziforblok.Count];
                diziforblok.CopyTo(sArray, 0);
                string blok = "";

                for (int i = 0; i < sArray.Length; i++)
                {
                    sArray[i] = sArray[i].Replace("–", "-");
                    sArray[i] = sArray[i].Replace("[", "");
                    sArray[i] = sArray[i].Replace("]", "");
                    blok = blok + sArray[i] + " ";
                }
                //BURADA BLOK ATIFLAR 2-4 ŞEKLİNDE OLANLAR SADECE SAYILARI ALIYORUZ
                Regex rxforcontrolblok2 = new Regex(@"[0-9*]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match matchforcontrolblok2 = rxforcontrolblok2.Match(blok);
                List<String> diziforblok2 = new List<String>();
                while (matchforcontrolblok2.Success)
                {
                    diziforblok2.Add(matchforcontrolblok2.Value);
                    matchforcontrolblok2 = matchforcontrolblok2.NextMatch();
                }
                int[] bloksayılar = new int[diziforblok2.Count];
                for (int i = 0; i < diziforblok2.Count; i++)
                {
                    bloksayılar[i] = Convert.ToInt32(diziforblok2[i]);
                }
                for (int i = 0; i < bloksayılar.Length; i = i + 2)
                {

                    if ((bloksayılar[i + 1] - bloksayılar[i]) + 1 > 3)
                    {

                        wrongsArray.Add("Blok atıf sayısı 3'ten fazla: [" + bloksayılar[i] + "-" + bloksayılar[i + 1] + "],Kaynaklar");
                    }
                    else
                    {
                        dizikontrol.Add("[" + (bloksayılar[i].ToString()) + "]");
                        dizikontrol.Add("[" + (bloksayılar[i + 1].ToString()) + "]");
                        dizikontrol.Add("[" + (bloksayılar[i] + bloksayılar[i + 1] / 2).ToString() + "]");
                    }

                }
                List<String> asd = new List<String>(dizikontrol);

                //Console.WriteLine("BLOK ATIFLAR:");

                //KAYNAKLAR SON KARŞILAŞTIRMA
                HashSet<String> son = new HashSet<String>();

                for (int i = 0; i < asd.Count; i++)
                {

                    for (int j = 0; j < dizi2.Count; j++)
                    {
                        if (!asd.Contains(dizi2[j]))
                        {
                            son.Add(dizi2[j]);
                        }
                    }
                }

                List<String> son2 = new List<String>(son);
                if (son2.Count > 0)
                {
                    for (int i = 0; i < son2.Count; i++)
                    {
                        wrongsArray.Add("\n" + son2[i] + " REFERANS YOK,Kaynaklar");
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("HATA OLUŞTU: kaynakcanin konrolunu yapilamadi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        static bool SekillerListesi()
        {
            try
            {
                //Eski
                //int endIndex = text.LastIndexOf("TABLOLAR") - text.LastIndexOf("ŞEKİLLER");
                //string sekillerlistesi = text.Substring(text.LastIndexOf("ŞEKİLLER"), endIndex);

                string sekillerlistesi = String.Empty;
                if (genelKontrol[5] == false)
                {
                    wrongsArray.Add("ŞEKİLLER LİSTESİ KISMI BULUNMADI!!,Şekiller Listesi");
                    return false;
                }

                else
                {
                    //genel kontrol metodundaki ana basliklar dizisinin sirasinda gore Icindekiler(2) -> 1.Giris(9)
                    for (int i = 6; i <= 9; i++)
                    {
                        if (genelKontrol[i] == true)
                        {
                            int endIndex = text.LastIndexOf(anaBaslik[i]) - text.LastIndexOf("ŞEKİLLER");
                            sekillerlistesi = text.Substring(text.LastIndexOf("ŞEKİLLER"), endIndex);
                            break;
                        }
                    }
                }

                    //Console.WriteLine(sekillerlistesi);
                    //Şekil\s\d*\.\d*\.
                    //SADECE ŞEKİLLER LİSTESİ KISMINI BULUYOR
                    Regex rx = new Regex(@"Şekil\s\d*\.\d*\.", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match match = rx.Match(sekillerlistesi);

                List<String> sekillerListesiSade = new List<String>();
                while (match.Success)
                {
                    sekillerListesiSade.Add(match.Value);
                    match = match.NextMatch();
                }

                string sekillerWithout = text.Substring(text.IndexOf("GİRİŞ"));


                //METNİ TARIYOR İÇERİDEKİ şekiller şekiller listesi HARİÇ BULUYOR
                Regex rxkontrol = new Regex(@"Şekil\s\d*\.\d*\.", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match matchkontrol = rxkontrol.Match(sekillerWithout);
                HashSet<String> sekillerLisesiWithout = new HashSet<String>();
                while (matchkontrol.Success)
                {
                    sekillerLisesiWithout.Add(matchkontrol.Value);
                    matchkontrol = matchkontrol.NextMatch();
                }

                List<String> asd = new List<String>(sekillerLisesiWithout);

                //SEKİLLER SON KARŞILAŞTIRMA
                //HashSet<String> son = new HashSet<String>();

                for (int i = 0; i < asd.Count; i++)
                {
                    for (int j = 0; j < sekillerListesiSade.Count; j++)
                    {
                        if (!asd.Contains(sekillerListesiSade[j]))
                        {
                            wrongsArray.Add(sekillerListesiSade[j] + " ŞEKİL KULLANILMADI!,Şekiller Listesi");
                        }
                    }
                }

                //List<String> son2 = new List<String>(son);
                //if (son2.Count > 0)
                //{
                //    for (int i = 0; i < son2.Count; i++)
                //    {
                //        rapor = rapor + "\n" + son2[i] + " ŞEKİL KULLANILMADI!";
                //    }
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("HATA OLUŞTU: Sekiller listesinin konrolunu yapilamadi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        static bool TablolarListesi()
        {
            try
            {
                //int endIndex = text.LastIndexOf("EKLER LİSTESİ") - text.LastIndexOf("TABLOLAR LİSTESİ");
                //string tablolarlistesi = text.Substring(text.LastIndexOf("TABLOLAR LİSTESİ"), endIndex);

                string tablolarlistesi = String.Empty;
                if (genelKontrol[6] == false)
                {
                    wrongsArray.Add("TABLOLAR LİSTESİ KISMI BULUNMADI!!,Tablolar Listesi");
                    return false;
                }

                else
                {
                    //genel kontrol metodundaki ana basliklar dizisinin sirasinda gore Icindekiler(2) -> 1.Giris(9)
                    for (int i = 7; i <= 9; i++)
                    {
                        if (genelKontrol[i] == true)
                        {
                            int endIndex = text.LastIndexOf(anaBaslik[i]) - text.LastIndexOf("TABLOLAR LİSTESİ");
                            tablolarlistesi = text.Substring(text.LastIndexOf("TABLOLAR LİSTESİ"), endIndex);
                            break;
                        }
                    }
                }

                //Console.WriteLine(sekillerlistesi);
                //Şekil\s\d*\.\d*\.
                //SADECE ŞEKİLLER LİSTESİ KISMINI BULUYOR
                Regex rx = new Regex(@"Tablo\s\d*\.\d*\.", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match match = rx.Match(tablolarlistesi);

                List<String> tablolarListesiSade = new List<String>();
                while (match.Success)
                {
                    tablolarListesiSade.Add(match.Value);
                    match = match.NextMatch();
                }



                string tablolarWithout = text.Substring(text.IndexOf("GİRİŞ"));


                //METNİ TARIYOR İÇERİDEKİ şekiller şekiller listesi HARİÇ BULUYOR
                Regex rxkontrol = new Regex(@"Tablo\s\d*\.\d*\.", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match matchkontrol = rxkontrol.Match(tablolarWithout);
                HashSet<String> tablolarLisesiWithout = new HashSet<String>();
                while (matchkontrol.Success)
                {
                    tablolarLisesiWithout.Add(matchkontrol.Value);
                    matchkontrol = matchkontrol.NextMatch();
                }

                List<String> asd = new List<String>(tablolarLisesiWithout);

                //SEKİLLER SON KARŞILAŞTIRMA
                //HashSet<String> son = new HashSet<String>();

                for (int i = 0; i < asd.Count; i++)
                {

                    for (int j = 0; j < tablolarListesiSade.Count; j++)
                    {
                        if (!asd.Contains(tablolarListesiSade[j]))
                        {
                            wrongsArray.Add(tablolarListesiSade[j] + " TABLO KULLANILMADI!,Tablolar Listesi");
                        }
                    }
                }

                //List<String> son2 = new List<String>(son);
                //if (son2.Count > 0)
                //{
                //    for (int i = 0; i < son2.Count; i++)
                //    {
                //        rapor = rapor + "\n" + son2[i] + " TABLO KULLANILMADI!";
                //    }
                //    Console.WriteLine(rapor);
                //}
                //else
                //{
                //    rapor = rapor + "\nTablolar Listesi'nde Hata Bulunamadı";
                //    Console.WriteLine(rapor);
                //}
            }
            catch (Exception Ex)
            {
                MessageBox.Show("HATA OLUŞTU: Tablolar listesinin konrolunu yapilamadi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        static bool EklerListesi()
        {
            try
            {
                //Eski
                //int endIndex = text.LastIndexOf("SİMGELER VE KISALTMALAR") - text.LastIndexOf("EKLER LİSTESİ");
                //string eklerlistesi = text.Substring(text.LastIndexOf("EKLER LİSTESİ"), endIndex);

                string eklerlistesi = String.Empty;
                if (genelKontrol[7] == false)
                {
                    wrongsArray.Add("EKLER LİSTESİ KISMI BULUNMADI!!,Ekler Listesi");
                    return false;
                }

                else
                {
                    //genel kontrol metodundaki ana basliklar dizisinin sirasinda gore ekler(6) -> 1.Giris(9)
                    for (int i = 8; i <= 9; i++)
                    {
                        if (genelKontrol[i] == true)
                        {
                            int endIndex = text.LastIndexOf(anaBaslik[i]) - text.LastIndexOf("EKLER LİSTESİ");
                            eklerlistesi = text.Substring(text.LastIndexOf("EKLER LİSTESİ"), endIndex);
                            break;
                        }
                    }
                }

                //Console.WriteLine(sekillerlistesi);
                //Şekil\s\d*\.\d*\.
                //SADECE ŞEKİLLER LİSTESİ KISMINI BULUYOR
                Regex rx = new Regex(@"EK\-\s\d*:|EK\s\-\s\d*:|EK\s\-\s\d*\s:|EK\-\s\d*:|EK-\d:|EK-\d\s:|EK\s-\d:", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match match = rx.Match(eklerlistesi);

                List<String> eklerListesiSade = new List<String>();
                while (match.Success)
                {
                    eklerListesiSade.Add(match.Value);
                    match = match.NextMatch();
                }



                string eklerWithout = text.Substring(text.IndexOf("GİRİŞ"));


                //METNİ TARIYOR İÇERİDEKİ şekiller şekiller listesi HARİÇ BULUYOR
                Regex rxkontrol = new Regex(@"EK\-\s\d*:|EK\s\-\s\d*:|EK\s\-\s\d*\s:|EK\-\s\d*:|EK-\d:|EK-\d\s:|EK\s-\d:", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Match matchkontrol = rxkontrol.Match(eklerWithout);
                HashSet<String> eklerLisesiWithout = new HashSet<String>();
                while (matchkontrol.Success)
                {
                    eklerLisesiWithout.Add(matchkontrol.Value);
                    matchkontrol = matchkontrol.NextMatch();
                }

                List<String> asd = new List<String>(eklerLisesiWithout);

                //SEKİLLER SON KARŞILAŞTIRMA
                HashSet<String> son = new HashSet<String>();

                for (int i = 0; i < asd.Count; i++)
                {

                    for (int j = 0; j < eklerListesiSade.Count; j++)
                    {
                        if (!asd.Contains(eklerListesiSade[j]))
                        {
                            wrongsArray.Add(eklerListesiSade[j]+ " EK KULLANILMADI!,Ekler Listesi");
                        }
                    }
                }

                //List<String> son2 = new List<String>(son);
                //if (son2.Count > 0)
                //{
                //    for (int i = 0; i < son2.Count; i++)
                //    {
                //        rapor = rapor + "\n" + son2[i] + " EK KULLANILMADI!";
                //    }
                //    Console.WriteLine(rapor);
                //}
               
            }
            catch (Exception)
            {
                MessageBox.Show("HATA OLUŞTU: Ekler listesinin konrolunu yapilamadi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog opendialog = new OpenFileDialog() { Filter = "PDF File|*.pdf" })
                {
                    if (opendialog.ShowDialog() == DialogResult.OK)
                    {
                        lblLocation.Text = opendialog.FileName;
                        lblLocation.ForeColor = Color.White;
                        path = opendialog.FileName;

                        text = extractText(path);

                        GenelKontrol(this);
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Lütfen doğru PDF dosyası ekleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            catch (IOException)
            {
                MessageBox.Show("Lütfen girdiğiniz dosyanın sağlamlığını kontrol ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            path = null;
            lblLocation.Text = "//Lütfen kontrol etmek istediğniz tezin PDF dosyası ekleyiniz.";
            lblLocation.ForeColor = Color.DarkGray;
            //this.Size = new Size(866, 224);
            Clear();
        }

        private void Clear ()
        {
            this.Size = new Size(866, 224);
            this.Top = 300;
            lblLoading.Visible = false;
            btnControl.Enabled = true;
            dgvHatalar.Rows.Clear();
            wrongsArray.Clear();

            lblDurumEkler.Text = "İşlenir ..";
            lblDurumIcindekiler.Text = "İşlenir ..";
            lblDurumKaynak.Text = "İşlenir ..";
            lblDurumKelime.Text = "İşlenir ..";
            lblDurumSekil.Text = "İşlenir ..";
            lblDurumTirnak.Text = "(“) ifadesi metinde 0 defa geçiyor.";
            lblDurumTablo.Text = "İşlenir ..";

            lblDurumEkler.ForeColor = Color.SteelBlue;
            lblDurumIcindekiler.ForeColor = Color.SteelBlue;
            lblDurumKaynak.ForeColor = Color.SteelBlue;
            lblDurumKelime.ForeColor = Color.SteelBlue;
            lblDurumSekil.ForeColor = Color.SteelBlue;
            lblDurumTirnak.ForeColor = Color.MediumSeaGreen;
            lblDurumTablo.ForeColor = Color.SteelBlue;

            foreach (var series in pieChart.Series)
            {
                series.Points.Clear();
            }
        }

        static List<String> wrongsArray = new List<string>();
        private void btnControl_Click(object sender, EventArgs e)
        {

            try
            {
                if (path == null)
                {
                    MessageBox.Show("Lütfen kontrol etmek istediğniz tezin PDF dosyası ekleyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                int totalErrorNum = 0;
                bool flag;

                #region icindekiler kontrolu
                wrongsArray.AddRange(IcindekilerKontrolu());
                if (wrongsArray.Count != totalErrorNum)
                {
                    lblDurumIcindekiler.Text = (wrongsArray.Count - totalErrorNum).ToString() + " Hata var";
                    lblDurumIcindekiler.ForeColor = Color.Brown;
                    totalErrorNum = wrongsArray.Count;

                    pieChart.Series["s1"].Points.AddXY("İçindekiler", totalErrorNum.ToString());
                }

                else
                {
                    lblDurumIcindekiler.Text = "Doğru";
                    lblDurumIcindekiler.ForeColor = Color.MediumSeaGreen;
                }
                #endregion

                #region Sekiller listesi kontrolu
                flag = SekillerListesi();
                if (wrongsArray.Count != totalErrorNum)
                {
                    lblDurumSekil.Text = (wrongsArray.Count - totalErrorNum).ToString() + " Hata var";
                    lblDurumSekil.ForeColor = Color.Brown;
                    totalErrorNum = wrongsArray.Count;

                    pieChart.Series["s1"].Points.AddXY("Şekiller Listesi", totalErrorNum.ToString());
                }

                else
                {
                    if (flag == false)
                    {
                        lblDurumSekil.Text = "Format Hatası";
                        lblDurumSekil.ForeColor = Color.Brown;
                    }
                    else
                    {
                        lblDurumSekil.Text = "Doğru";
                        lblDurumSekil.ForeColor = Color.MediumSeaGreen;

                    }
                }
                #endregion

                #region Tablolar listesi kontrolu
                flag = TablolarListesi();
                if (wrongsArray.Count != totalErrorNum)
                {
                    lblDurumTablo.Text = (wrongsArray.Count - totalErrorNum).ToString() + " Hata var";
                    lblDurumTablo.ForeColor = Color.Brown;
                    totalErrorNum = wrongsArray.Count;

                    pieChart.Series["s1"].Points.AddXY("Tablolar Listesi", totalErrorNum.ToString());
                }

                else
                {

                    if (flag == false)
                    {
                        lblDurumTablo.Text = "Format Hatası";
                        lblDurumTablo.ForeColor = Color.Brown;
                    }
                    else
                    {
                        lblDurumTablo.Text = "Doğru";
                        lblDurumTablo.ForeColor = Color.MediumSeaGreen;
                    }
                }
                #endregion

                #region Ekler listesi kontrolu
                flag = EklerListesi();
                if (wrongsArray.Count != totalErrorNum)
                {
                    lblDurumEkler.Text = (wrongsArray.Count - totalErrorNum).ToString() + " Hata var";
                    lblDurumEkler.ForeColor = Color.Brown;
                    totalErrorNum = wrongsArray.Count;

                    pieChart.Series["s1"].Points.AddXY("Ekler Listesi", totalErrorNum.ToString());
                }

                else
                {
                    if (flag == false)
                    {
                        lblDurumEkler.Text = "Format Hatası";
                        lblDurumEkler.ForeColor = Color.Brown;
                    }
                    else
                    {
                        lblDurumEkler.Text = "Doğru";
                        lblDurumEkler.ForeColor = Color.MediumSeaGreen;
                    }
                }
                #endregion

                #region Kaynakca kontrolu
                flag = KaynakcaKontrol();
                if (wrongsArray.Count != totalErrorNum)
                {
                    lblDurumKaynak.Text = (wrongsArray.Count - totalErrorNum).ToString() + " Hata var";
                    lblDurumKaynak.ForeColor = Color.Brown;
                    totalErrorNum = wrongsArray.Count;

                    pieChart.Series["s1"].Points.AddXY("Kaynaklar", totalErrorNum.ToString());
                }

                else
                {
                    if (flag == false)
                    {
                        lblDurumKaynak.Text = "Format Hatası";
                        lblDurumKaynak.ForeColor = Color.Brown;
                    }
                    else
                    {
                        lblDurumKaynak.Text = "Doğru";
                        lblDurumKaynak.ForeColor = Color.MediumSeaGreen;
                    }
                }
                #endregion

                #region Kelimeler kontrolu
                KelimeKontrol();
                if (wrongsArray.Count != totalErrorNum)
                {
                    lblDurumKelime.Text = (wrongsArray.Count - totalErrorNum).ToString() + " Hata var";
                    lblDurumKelime.ForeColor = Color.Brown;
                    totalErrorNum = wrongsArray.Count;

                    pieChart.Series["s1"].Points.AddXY("Kelimeler", totalErrorNum.ToString());
                }

                else
                {
                    lblDurumKelime.Text = "Doğru";
                    lblDurumKelime.ForeColor = Color.MediumSeaGreen;
                }
                #endregion

                TirnakKontrol(this);

                this.Size = new Size(866, 581);
                //pieChart.ChartAreas.Clear();
                btnControl.Enabled = false;
                this.Top = 85;
                lblLoading.Visible = false;
            }

            catch (Exception) { MessageBox.Show("Girilen tez dosyası uygun formatte değildir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnDetailes_Click(object sender, EventArgs e)
        {
            pnlDetailes.Visible = true;
            
            if (dgvHatalar.Rows.Count == 0)
            {
                foreach (string str in wrongsArray)
                {
                    int index = str.IndexOf(',');
                    dgvHatalar.Rows.Add(str.Substring(0, index), str.Substring(index + 1, (str.Length - 1) - index));
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            pnlDetailes.Visible = false;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        //Moving borderless form dynamically
        int mouseX = 0, mouseY = 0, mouseinX = 0 , mouseinY = 0;
        bool mouseDown;


        ToolTip t1 = new ToolTip();
        string[] aciklamalar = new string[7] { "Tezin içindekiler kısmındaki eklenen başlıkların\ntezin içinde doğru sayfada geçtiğini kontrol etmek." 
                                              ,"Tezin sekiller listesi kısmındaki eklenen sekiller\ntezin içinde doğru sayfada geçtiğini kontrol etmek."
                                              ,"Tezin tablolar listesi kısmındaki eklenen tablolar\ntezin içinde doğru sayfada geçtiğini kontrol etmek."
                                              ,"Tezin ekler listesi kısmındaki eklenen ekler\ntezin içinde doğru sayfada geçtiğini kontrol etmek."
                                              ,"Tezin kaynaklar kısmındaki eklenen kaynaklar\ntezin içinde doğru bir şekide geçtiğini kontrol etmek."
                                              ,"Tezin metni sık yanlış yazılabilen kelimelere göre kontrol etmek."
                                              ,"Tezin içinde tırnak sayısı (“) (Tezin içinde kaç tane alıntı var) göstermek." };
        private void CommonInfoPictureBox_MouseHover(object sender, EventArgs e)
        {
            PictureBox box = sender as PictureBox;
            int index = Convert.ToInt32(box.Name.Substring(box.Name.Length - 1)) - 1;
            t1.Show(aciklamalar[index].ToString(), box);
        }

        private void pnlHeading_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseinX = MousePosition.X - Bounds.X;
            mouseinY = MousePosition.Y - Bounds.Y;
        }

        private void pnlHeading_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pnlHeading_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - mouseinX;
                mouseY = MousePosition.Y - mouseinY;

                this.SetDesktopLocation(mouseX, mouseY);
            }

        }

    }
}

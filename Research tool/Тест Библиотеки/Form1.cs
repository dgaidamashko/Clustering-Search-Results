using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StopWords;


namespace ClusteringSearchResults 
{
    public partial class Form1 : Form
    {
        
        Form2 F;
        string[] t;

        static int formwidth, formheight;

        public Form1()
        {
            InitializeComponent();
            F = new Form2();
            formwidth = F.Size.Width;
            formheight = F.Size.Height;
            t = new string[]{    "Андре Александрович Мирон (фамил при — Мена́кер[1]; 7 март 1941, Москв — 16 август 1987, Рига) — советск актёр театр и кино, артист эстрады. Народн артист РСФСР (1980).",
                                   "Евген Витальевич Мирон (род. 29 ноябр 1966, Саратов, СССР) — советск и российск актёр театр и кино, народн артист Росс (2004)[1], лауреат двух Государствен прем Российск Федерации.",
                                   "Серг Михайлович Мирон (14 феврал 1953, Пушкин, Ленинград) — российск политическ и государствен деятель, депутат Государствен дум VI созыва, руководител фракц парт «Справедлив Россия» в Государствен думе, председател совет Палат депутат парт «Справедлив Россия» — член бюр президиум Центральн совет парт (2011—2013). Ран — депутат Государствен дум V созыв (2011), Председател Совет Федерац (2001—2011), депутат Законодательн собран Санкт-Петербург (1994—2001). Председател парт «Справедлив Россия» в 2006—2011 и с 27 октябр 2013 года, ран — председател Российск парт Жизни. Выставля сво кандидатур на выбор президент РФ в 2004 и 2012 год и об раз занима последн место. Председател Наблюдательн совет «Союз десантник России».",
                                   "Руководител фракц «Справедлив Россия» в Госдум Серг Мирон предлож запрет реклам кредит и займ посредств наружн рекламы, SMS-рассылок и проч носителей. Политик подготов соответств поправк в КоАП, пишет газет «Известия». Согласн документу, за распространен реклам кредит и займ предусмотр штраф. Для физическ лиц ег величин состав до 5 тысяч рублей; для индивидуальн предпринимател — до 50 тысяч рублей, для юрлиц — до 1 миллион рублей. Банк смогут рекламирова сво услуг тольк в собствен офисах. Как говор в пояснительн записк к законопроекту, в кризис «широк реклам потребительск кредит посредств наружн рекламы, телевизион и радиовещания, SMS-рассылок, листовок, объявлен и т.д. приобрел характер массов социальн провокации». При эт «невозможн погашен населен кредит стал существен фактор не тольк экономическ проблем, но и повышен социальн напряжен в целом», отмеча автор. По мнен Миронова, запрет на реклам кредит «поможет уменьш количеств иск о невозвращен кредитах, сниз ставк по потребительск кредитам, увелич социальн ответствен гражда и укреп их финансов независимость». Он добавил, что решен гражда об обращен за кредит «должн быт хорош обдуманным, принят с должн мер ответственности, а не явля прям следств агрессивн рекламн кампаний». В комитет по финансов рынку, по слов член эт комитет коммунист Борис Кашина, поддержа законопроект пок не готовы.",
                                   "Актер, Режиссер рост 1.82 м 8 марта, 1941 • рыб рыб Москва, СССР (Россия) дат смерт 16 авгуcта, 1987 • 46 лет Рига, СССР (Латвия) жанр комедия, драма, мелодрам супруг Екатерин Градов (развод) ... один ребенок Ларис Голубкин всег фильм 70, 1962 — 1993",
                                   "Актер, Продюсер, Актер: Дубляж, Режиссер, Сценарист рост 1.73 м 29 ноября, 1966 • стрелец стрелец • 48 лет Татищево, Саратовск область, СССР (Россия) жанр драма, комедия, воен всег фильм 72, 1987 — 2017",
                               };
            TextOperations.InitParams(t);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                TextOperations.ts.Add(richTextBox1.Text);
                listBox1.Items.Add(TextOperations.ts[TextOperations.ts.Count - 1]);
                richTextBox1.Text = "";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            TextOperations.TagNullifier();
            for (int i = 0; i < TextOperations.ts.Count; i++)
            {
                TextOperations.Tag.Add(TextOperations.Frequency(TextOperations.vClusterize(TextOperations.ts[i].ToString())));
            }
            TextOperations.FormMatrix();
            F.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        //Стемминг слова
        #region
        /*string Stemming(string data, string language)
        {
            var engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            ScriptSource ss = engine.CreateScriptSourceFromFile("script.py");
            CompiledCode code = ss.Compile();
            scope = code.DefaultScope;
            scope.SetVariable("word", data);
            scope.SetVariable("lang", language);
            code.Execute();
            data = scope.GetVariable<string>("stemmed");
            return data;
        }*/
        #endregion

        public static int GetForm2Width
        {
            get { return formwidth; }
            set { formwidth = value; }
        }
        public static int GetForm2Height
        {
            get { return formheight; }
            set { formheight = value; }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        void UpdateForm2Params(object sender, EventArgs e)
        {
            formheight = F.Size.Height;
            formwidth = F.Size.Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextOperations.TagNullifier();
            for (int i = 0; i < TextOperations.ts.Count; i++)
            {
                TextOperations.Tag.Add(TextOperations.Frequency(TextOperations.vClusterize(TextOperations.ts[i].ToString())));
            }
            TextOperations.FormMatrix();
            F.ShowDialog();
            this.Close();
        }

    }
}

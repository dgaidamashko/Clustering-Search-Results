﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClusteringSearchResults
{
    static class TestData
    {
        public static List<string[]> Texts = new List<string[]>();
        public static void SetData()
        {
            Texts.Add(new string[]{    "Андре Александрович Мирон (фамил при — Мена́кер[1]; 7 март 1941, Москв — 16 август 1987, Рига) — советск актёр театр и кино, артист эстрады. Народн артист РСФСР (1980).",
                                   "Евген Витальевич Мирон (род. 29 ноябр 1966, Саратов, СССР) — советск и российск актёр театр и кино, народн артист Росс (2004)[1], лауреат двух Государствен прем Российск Федерации.",
                                   "Серг Михайлович Мирон (14 феврал 1953, Пушкин, Ленинград) — российск политическ и государствен деятель, депутат Государствен дум VI созыва, руководител фракц парт «Справедлив Россия» в Государствен думе, председател совет Палат депутат парт «Справедлив Россия» — член бюр президиум Центральн совет парт (2011—2013). Ран — депутат Государствен дум V созыв (2011), Председател Совет Федерац (2001—2011), депутат Законодательн собран Санкт-Петербург (1994—2001). Председател парт «Справедлив Россия» в 2006—2011 и с 27 октябр 2013 года, ран — председател Российск парт Жизни. Выставля сво кандидатур на выбор президент РФ в 2004 и 2012 год и об раз занима последн место. Председател Наблюдательн совет «Союз десантник России».",
                                   "Руководител фракц «Справедлив Россия» в Госдум Серг Мирон предлож запрет реклам кредит и займ посредств наружн рекламы, SMS-рассылок и проч носителей. Политик подготов соответств поправк в КоАП, пишет газет «Известия». Согласн документу, за распространен реклам кредит и займ предусмотр штраф. Для физическ лиц ег величин состав до 5 тысяч рублей; для индивидуальн предпринимател — до 50 тысяч рублей, для юрлиц — до 1 миллион рублей. Банк смогут рекламирова сво услуг тольк в собствен офисах. Как говор в пояснительн записк к законопроекту, в кризис «широк реклам потребительск кредит посредств наружн рекламы, телевизион и радиовещания, SMS-рассылок, листовок, объявлен и т.д. приобрел характер массов социальн провокации». При эт «невозможн погашен населен кредит стал существен фактор не тольк экономическ проблем, но и повышен социальн напряжен в целом», отмеча автор. По мнен Миронова, запрет на реклам кредит «поможет уменьш количеств иск о невозвращен кредитах, сниз ставк по потребительск кредитам, увелич социальн ответствен гражда и укреп их финансов независимость». Он добавил, что решен гражда об обращен за кредит «должн быт хорош обдуманным, принят с должн мер ответственности, а не явля прям следств агрессивн рекламн кампаний». В комитет по финансов рынку, по слов член эт комитет коммунист Борис Кашина, поддержа законопроект пок не готовы.",
                                   "Актер, Режиссер рост 1.82 м 8 марта, 1941 • рыб рыб Москва, СССР (Россия) дат смерт 16 авгуcта, 1987 • 46 лет Рига, СССР (Латвия) жанр комедия, драма, мелодрам супруг Екатерин Градов (развод) ... один ребенок Ларис Голубкин всег фильм 70, 1962 — 1993",
                                   "Актер, Продюсер, Актер: Дубляж, Режиссер, Сценарист рост 1.73 м 29 ноября, 1966 • стрелец стрелец • 48 лет Татищево, Саратовск область, СССР (Россия) жанр драма, комедия, воен всег фильм 72, 1987 — 2017",
                               });
            Texts.Add(new string[]{"Британск полиц знает о местонахожден основател WikiLeaks",
"В суд США начина процесс прот россиянина, рассыла спам",
"Церемон вручен Нобелевск прем мир бойкотир 19 стран",
"В Великобритан арестова основател сайт Wikileaks Джулиа Ассандж",
"Украин игнорир церемон вручен Нобелевск прем",
"Шведск суд отказа рассматрива апелляц основател Wikileaks",
"НАТО и США разработа план оборон стран Балт прот Росс",
"Полиц Великобритан нашл основател WikiLeaks, но, не арестова",
"В Стокгольм и Осло сегодн состо вручен Нобелевск прем",
                               });
            Texts.Add(new string[]{"Кремен (мини-сериал) Кремен (Kremen) Год 2012 (1 сезон) Стран Росс слога «Его правд - ег оружие» режиссер Владимир Епифанцев, Александр Аншютц сценар Миха Шульма продюсер Алекс Моисеев, Давид Дишдишян, Светла Слитюк, ... оператор Виктор Гончар композитор Игор Баба художник Евген Драбкин, Жан Сердюк жанр боевик, криминал, детект",
            "Кремен (праслав. *kremy, род. п. kremene; ст. слав. кремы, род. п. кремене)[1] — минеральн образование, состоя из кристаллическ и аморфн кремнезём (SiO2) в осадочн горн породах. Част окраш окисл желез и марганц в разн цвета, с плавн переход межд ними.",
            "Росс Детективы, Боевики, Русск Режиссер Владимир Епифанцев, Александр Аншютц В рол Владимир Епифанцев, Павел Климов, Анастас Веденская, Серг Векслер, Иван Краско, ещ Отечествен кинематографист замахнул на святое, реш снят российск аналог кинохит всех врем и народ «Рэмбо: перв кровь». Так на экра вышел мини-сериа под назван «Кремень» с Владимир Епифанцев в главн роли. В результат получ криминальн боевик про оборотн в погон и отчая борьб с ними. Посмотрет на то, как лих русск Рэмб справля с продажн русск копами, можн онлайн. Слога фильм – «Его правд – ег оружие».",
        "минер. горн порода, разновидн кремнезёма, очен твёрды минерал, состоя из кварц и халцедон (конкрец SiO2 в осадочн горн породах) ◆ И опя ползём мы по щел вверх; отсюд уж заметн горизонтальн тонк сло кремня, параллельн друг друг скрепля мелов породу. В. И. Немирович-Данченко, «Свят горы», 1880 г. (цитат из Национальн корпус русск языка, см. Список литературы) ◆ Зде пласт лежат плитняк, глина, мелк кремен и чёрна галька, а мест ест такж прослойк и друг землист пород, то тёмные, то иссера-жёлтые, то совс беловатые. Н. С. Лесков, «Гора», 1888 г. (цитат из Национальн корпус русск языка, см. Список литературы) ◆ Кремен — главн материа для топоров, стрел, нож и проч нужн инструментов, — а такж издел из нег использова для обм на медные,"});
            Texts.Add(new string[]{"Кандидат в президент США: Обам не смог постав Путин на колени С точк зрен Рик Перри, представител Республиканск партии, Обам долж был постав Украин вооружение, а такж заключ больш количеств контракт по поставк газ в Европу. Об эт он заяв в эфир Fox News.",
        "Бара́к Хуссе́йн Оба́ма-младш (англ. Barack Hussein Obama II, произнос [bəˈrɑːk huːˈseɪn oʊˈbɑːmə]; род. 4 август 1961, Гонолулу, Гавайи, США)[2] — действ (с 20 январ 2009 года) 44-й президент Соединён Штат Америки. Лауреат Нобелевск прем мир 2009 года. До избран президент был федеральн сенатор от штат Иллинойс. Был переизбра на втор срок в 2012 году. Перв афроамериканец, выдвинут на пост президент США от одн из двух крупн партий[3], и перв в национальн истор глав государств темнокож президент, а такж президент с фамил африканск и средн имен арабск этимологическ происхождения. Обам — мулат, но, в отлич от большинств чёрных американцев, не потомок рабов, а сын студент из Кен и бел американк (Стэнл Энн Данхэм). Выпускник Колумбийск университет и Школ прав Гарвардск университета, где он такж был перв за всю ег истор афроамериканцем-редактор университетск издан «Harvard Law Review». Обам такж работа обществен организатор и адвокат в област гражданск прав. Преподава конституцион прав в Чикагск институт юридическ наук с 1992 по 2004 год и одновремен трижды, в период с 1997 по 2004 год, избира в сенат штат Иллинойс. Посл неудачн попытк баллотирова в 2000 год в Палат представител США в январ 2003 год баллотирова в Сенат США. Посл побед на праймериз (первичн выборах) в март 2004 год Обам произнёс основн реч на Демократическ национальн съезд в июл 2004 года. Был избра в Сенат в ноябр 2004 года, набра 70 % голосов. Как член Демократическ меньшинств в Конгресс 109-го созыва, он помог созда закон о регулирован обычн вооружен и увеличен прозрачн в использован государствен бюджета. Он такж соверш официальн поездк в Восточн Европ (в том числ в Россию), на Ближн Восток и в Африку. Во врем работ в Конгресс 110-го созыв участвова в создан законов, каса мошенничеств на выборах, лоббизма, изменен климата, ядерн терроризм и демобилизова американск военнослужащих. Обам объяв о своём желан баллотирова в президент в феврал 2007 год и в 2008 год на президентск праймериз на Демократическ национальн съезд был официальн выдвинут от Демократическ парт кандидат в президент вмест с кандидат на пост вице-президент — сенатор от штат Делавэр Джозеф Байденом. На президентск выбор 2008 год Обам оперед кандидат от прав Республиканск парт Джон Маккейна, набра 52,9% голос избирател и 365 голос в коллег выборщик прот 45.7% и 173 у Маккейна. 9 октябр 2009 год получ Нобелевск прем мир с формулировк «за экстраординарн усил в укреплен международн дипломат и сотрудничеств межд людьми»[4].[⇨] На президентск выбор 2012 год Обам оперед кандидат от Республиканск парт Митт Ромни, набра 51,1% голос избирател и 332 голос в коллег выборщик прот 47,2% и 206 у Ромни.",    
        "Обам признался, что политик санкц не работа  В Америк дискусс об ужесточен антироссийск санкц идут в преддвер выбор нов президента. А что там? Может, посл Обам будет попроще? Две отличительн черт эт кампан уж очевидны. Во-первых, эт характерн династийность, пот что опя Буш (тепер Джеб) и Клинтон (тепер Хиллари). Выигра что те, что другие. Москв примерн понятно, чег ждать, — переосмыслен подход к Росс будет, скорее, ещ через президентство. Но будет тепер и ещ одна, совершен нов черт предвыборн кампан в США. Еще недавн главным меньшинств в США был афроамериканцы, тепер их по числен обошл избирател латиноамериканск кровей. Сам именит кандидатом-республиканц явля Джеб Буш — сын президент Буша-старш и брат президент Буша-младшего. У нег с латиноамериканц все прост замечательно. Супруг — мексиканка, и в сем он говор на испанском. Но и Хиллар Клинтон тепер ест что продать избирателям-латиноамериканцам, а имен решен е однопартийц Обам пойт на нормализац отношен с Кубой. Уже объявл об обмен посольствами. А тепер вспомн подвешенные бюллетен в подвешенном штат Флорид на президентск выбор 2000 года. Это был бесконечн пересчеты. Губернатор Флорид там был тогд Джеб Буш. Побед ег брат Джордж. Минимальн перевес обеспеч в том числ кубино-американск избиратели. Они традицион — за республиканцев. Каза бы, Буш неч беспокоиться. Как, мол, там ни мечут демократы, уж кубино-американск избирател за пазухой. Но вот ещ две нов черты. Во-первых, из числ кандидатов-республиканц кубино-американц куд ближ не Джеб Буш с ег женой-мексиканкой, а два так подпира ег кандидата, как сенатор Крус и особен сенатор Рубио, а он об — этническ кубинцы. Во-вторых, с памятн 2000 год Флорид наводн уж не тольк кубинц из железобетонно-антикоммунистическ волны, котор бежа туд от революц и традицион голосова за республиканцев, — все больш стал иммигрант свежих, уеха с Куб част не из-з идеологии, а в поисках, например, работы. Так нов кубинцы-иммигрант только-тольк высидели гражданств США, стал избирател и част жела как раз примирен с Гаван — им так прощ езд к родственникам. То ест баланс сдвинулся. Демократ продолжа ег сдвига ещ дальше. Они намекнул на нормализац отношен тепер и с Венесуэлой. А эт уж совс по наш душу, пот что имен Куб и Венесуэл — сам близк Росс латиноамериканск республики. И что будет, есл США их от нас уведут? Впрочем, уведут ли? И вот тут пригод сраз нескольк совпадений. Во-первых, недавн вышл нов книг о Куб легендарн советск разведчик Никол Леонова. А, во-вторых, 4 июл - Ден независим США, а 5-го — Ден независим Венесуэлы. Но из-з того, что в эт год об эт дат пришл на выходные, американск и венесуэльск посольств уж провел праздничн приемы, а дипломатическ раут — эт ещ как лакмусов бумажка. Так кто ког куд завлека и как развлекал? Сам необычн участник венесуэльск прием — юнош и девушки, у котор на плеч — нашивк со сво флагом, но на погон — русск букв К. Это курсанты, котор учат в воен вуз стран ОДКБ. Отношен Москв и Каракас стал сейчас так масштабными, что для венесуэльск прием аренд огромн зал в отел Метрополь. Сред гост мног не тольк дипломатов, но и представител российск бизнеса, прич реальн сектора. Кстати, российск триколор сопровожда венесуэльск независим с сам начала. Когд наш гер Франсиск де Миранд приб ко двор Екатерин Великой, уж тогд обсужда наш независим от испанск короны. А пот наш освободител Симон Боливар принес мног народ Латинск Америк независимость, свободу, отказ от тиран и подавления. И мы очен горды, что в Росс отмеча 204-ю годовщин наш независимости, — заяв Хуа Висент Паредес, посол Венесуэл в России. На 35 лет раньш имен Росс и все та же Екатерин Велик перв в мир призна и независим США. Поэт в Москве, как нигде, символичн то, что на дипприем в чест годовщин независим США посл вынос их флаг звуч гимн страны-хозяйк России. На стен резиденц США в Москв — фотограф о сам разн этап наш двусторон отношений. На прием нынешн посол Джон Теффт повел себ крайн сдержанно: в реч он лиш раз упомянул расхождения, а при посвят культуре. Особ популярн пользова постер с Фрэнк Синатрой: в эт год — 100 лет со дня ег рождения. По мо ощущениям, культурн обм растет. Конечно, над посмотрет точн цифры, но явн не снижается. Мы провод мног музыкальн концертов. Сегодн у нас — групп Сем Джонс. До эт он спел в разн город Росс и выступ в Москве. А недавн мы организова совместн концерт Игор Бутма и Теренс Бланшара, котор счита в США одн из лучш трубачей. Роскошн джаз, — призна Теффт. Национальн культур был и у венесуэльцев. Сам трогательн момент — вручен подарк 7-летн Саш Каплунову, победител уж 4-го конкурс рисунк Венесуэл глаз русск детей. Совс друг поколен чествова ран в Госдуме. Там прошл презентац нов книг легендарн советск разведчика-латиноамериканист Никол Сергеевич Леонов о Раул Кастро. - Никола Сергеевич, поч вдруг Раул Кастро? Времен мног прошло, врод всем все известно? - Времен прошл действительн много. С момент мо знакомств с Раул Кастр прошл 62 года. В книг — и их перв совместн фотограф — тогд он ещ был студент — и масс удивительн детск фотограф сам Рауля, и, естественно, Раул с брат Фидел и с советск товарищ по оружию. Межд тем, ровн в тот ден был объявлено, что у США тепер будет в Гаван посольство, как у Куб в Вашингтоне. Почему? Наш президент реш взят курс на нормализац отношен с Кубой. Он очен хочет, как мне кажется, налад связ с кубинц в новом, расширен ключе. Он четк сказал, что стар политик не работа и мы попробу вест другую, — отмет Джон Теффт. Но вед стар политика — эт политик санкций. Значит, он не работает. Куб их выдержа благодар поддержк Москвы. А друг позна в беде. Так друз остаются. Как бы стран ни был больш друг Кубы, так стран всегд будет испытыва больш выгод от стратегическ преимуществ Кубы. Оттуд все можн делать. И над прост радоваться, что у нас с не так хорош и добр отношения, — счита Никола Леонов. Но верн и то, что нормализац отношен с кубинц — то немногое, что Обам может приписа себ как внешнеполитическ успех. В Вашингтон уж идут дальше. Тепер нормализац обеща и Венесуэле, прот котор был немедлен введ санкции, сто то стран объяв о независим курсе. И опя же кто помог и кто сказал, что, конечн же, непрост внутрен процесс — эт дел сам венесуэльцев? Со времен перв встреч командант Чавес с президент Путин Росс стал для нас не прост ещ одн стран — эт братск страна. Так говор командант Чавес. Его дел продолжа президент Николас Мадуро. Это сближен служ дел создан многополярн мира. В эт — практик России. А из эт проистека суверенитет и цельност границ. Вот что мы ищ — мира, котор мы нес и друг народам, — сказа Хуа Висент Паредес. Не буд сравнива прием по случа Дне независим Венесуэл и США, замет только, что ни в посольств США не был кубинц с венесуэльцами, ни у венесуэльц не был американцев. Межд тем в российск Интернет гуляет занятн викторина. Поч в 1963 год Фидел Кастр в Москв нос сраз пар часов? В числ проч предлага верс тогдашних, врем холодн войны, конечно, западн пропагандистов. Мол, Фидел Кастр на сам дел тайн пита страст к роскоши. Или что Фидел разбогател на доверчив советск лидеров. На сам дел загадк проста: одн час на рук Фидел показыва местное, московское, время, а втор — домашнее, гаванское."});
            Texts.Add(new string[]{"Судьба — совокупн всех событ и обстоятельств, котор предопредел и в перв очеред влия на быт человека, народ и т. п.; предопределён событий, поступков; рок, фатум, доля; высш сила, котор может мысл в вид природ ил божества; древн грек персонифицирова судьб в виде: Мойр (Клото, Лахезис, Атропос), Тиха, Ате, Адрастеи, Хеймармене, Ананке; древн римлян — в вид Парк (Нона, Децима, Морта); слово, част встреча в биографическ текстах.",
            "Люд всех культур во все врем сталкива с эт проблемой, с эт двум подход к жизни: все ли предопредел ил мы мож каким-т способ измен ход событ — сил наш воли, наш желаний, наш слез, преодолен нам опасн и исправлен ошибок? Все известн нам культур и народ задава так вопросом, с ним был связа даж определен божества. Например, о традиц и истор Древн Рим нам известн сегодн (а сегодн нам известн горазд больше, чем деся лет том назад, когд считалось, что Рим основа тольк Ромул и Рем, когд не придава должн значен произведен Вергил и не учитыва символическ смысл миф об Эне и маленьк групп ег соратников), что римлян вер в Бог (он упомина в мифах), стоя выш Юпитера, божеств без имени, котор называ прост — Неизвестный.",
            "Судьб – многозначн термин, обозначающий: 1. предназначен (идеал); а) небесная: полн раскрыт Образ и Подоб Божия, жизн в Царств Небесном; б) земная: исполнен земн предназначения; земн реализац дан от Бог сил во слав Божию; 2. жизнен путь: исполнен ил неисполнен предназначен (например, Саул не исполн его, а Давид исполнил); 3. стечен обстоятельств (что ест Промысл Божий); 4. рок (неотвратимость)",
            "Сериа Судьба: Ноч схватки. Клинк бесконечн край/Fate-stay Night: Unlimited Blade Works 2 сезон онлайн Как и в прежн времена, в город Фуюк продолжа идт магическ битв за Свят Грааль. К ней, в сво очередь, присоединя ученик школ Сир Эмия, котор оказа в неизведа для себ мире. Все происход быстр и без четк позиции, альянс распада быстрей, чем создаются, а предател окружа повсюду. И в эт противостоян героев, в сюжет раскрыва нов история, котор покажет нам кое-чт про происхожден главн героев, а так же их отношен межд собой. Наш реальност состо из множеств пут и перекрестков, вступ на один из них, мы мож полност измен сво представлен о реальности, о сюжете, как здесь, когд оказыва под багрян светил на пустыр из клинков. У «Ноч схватки» тепер нов девиз, котор звуч так «Побольш дел, поменьш слов». В фильм представл отличн анимация, на сам современ уровне. Теперь, сражен в мир «Type-Moon» будут ещ восхитительней. Оригинал: Fate-stay Night: Unlimited Blade Works Жанр: аниме, приключения, фэнтез Страна: Япон Вышел: 2015 Режиссер: Миур Такахир",
            "Сериа Судьба: Ноч схватки/Fate-stay Night онлайн Потеря сво приемн отца, молод парен Сир Эми жил сам в огромн поместье. К 16-ти год парен вырос добрым, трудолюбив и хозяйственным, поэт ег окружа забот и вниман сраз две девушк — младш школьн подруг Сакур Мат и учительниц Тайг Фудзимура, котор формальн был ем опекуном, а на дел — скор старш сестрой. Всё пал прах посл того, как Сир узна о том, что ег родн городишк Фуюк явля арен магическ сражен за Свят Грааль, котор провод раз в нескольк поколений. Вот тольк жизн станов всё быстрее, и хот с последн битв прошл всег 10 лет — уж грядет нов война. Древн закон гласят, что в «королевск битве» участв сем Мастеров-магов, котор вызыва себ по одн Слуг — вечн гер прошедш ил будущ времени. Мастер, оста в живых, станов обладател Граал — величайш сокровища, исполня люб желание. В величайш битв нет никак правил, друг может стат соперник и предать, без промедлен нанест удар в спину. Узнавш горьк правд Сир долж соверш для себ тяжел выбор — отступить, отказа от борьб ил пойт в бой, риску жизн и постав на карт все, что у нег ест — невелик (как он сам считает) магическ способности, горяч сердце, безудержн желан спаст всех тех, кто для нег дорог. И когд все был уж почт решено, последн капл на чаш вес доблест и чест окажут зелен глаз из далек времен, засия в ту сам ночь Оригинал: Fate-stay Night Жанр: драмы, приключения, аним",
            "Судьба — совокупн всех событ и обстоятельств, котор предопредел и в перв очеред влия на быт человека, народ и т. п.; предопределён событий, поступков"
            });

            Texts.Add(new string[]{"Андре Александрович (фамил при рожден — Менакер 7 март 1941 Москв — 16 август 1987 Рига) — советск актёр театр и кин артист эстрад Народн артист РСФСР (1980)",
                " () — русск фамил образова от мужск имен Известн носител Александр Александрович (род 1961) — советск и российск актёр Александр Васильевич (1902—1980) — советск архитектор",
                "Обзор политическ деятельн обществ инициат Комментар к соб в обществ жизн Росс Материа интернет- и пресс-конференц Интернет-приёмн",
                "Мне очен важн ваш мнение Чувств себ как дома Ваш Евген ",
                "Серг Депутат Государств дум глав фракц Справедл Росс в Госдум пят созыв",
                "www.mironov.ru. sergey-mironov.livejournal.com. ... Серг суд над назначен заран виновным вряд ли получится",
                "Детств Евген Евген Витальевич род в город Сарат 29 ноябр 1966 год"
            });
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.Xml;
using System.IO;
using System.Net.Configuration;
using System.Xml.Linq;
using System.Net.Cache;

namespace Yandex.XML.Search
{
    public enum RequestMethodEnum { POST, GET }

    public struct YaSearchResult
    {
        public int Position;
        //url
        public string DisplayUrl,
            //saved-copy-url
        CacheUrl,
            //title
        Title,
            //headline
        Description,
            //modtime
        IndexedTime,
        Domain;

        public YaSearchResult(int position, string url,
                   string cacheUrl,
                   string title,
                   string description,
                   string indexedTime,
            string domain)
        {
            this.Position = position;
            this.DisplayUrl = url;
            this.CacheUrl = cacheUrl;
            this.Title = title;
            this.Description = description;
            this.IndexedTime = indexedTime;
            this.Domain = domain;
        }
    }
    // Регионы
    public class YandexRegion
    {

        public string StringName { get; set; }
        public long Key { get; set; }

        public static List<YandexRegion> GetList()
        {
            #region YandexRegionsList (ru)
            List<YandexRegion> result = new List<YandexRegion>();

            result.Add(new YandexRegion { Key = 0, StringName = "Регионы" });
            result.Add(new YandexRegion { Key = 1, StringName = "Москва и область" });
            result.Add(new YandexRegion { Key = 2, StringName = "Санкт-Петербург" });
            result.Add(new YandexRegion { Key = 2, StringName = "Санкт-Петербург" });
            result.Add(new YandexRegion { Key = 3, StringName = "Центр" });
            result.Add(new YandexRegion { Key = 4, StringName = "Белгород" });
            result.Add(new YandexRegion { Key = 5, StringName = "Иваново" });
            result.Add(new YandexRegion { Key = 6, StringName = "Калуга" });
            result.Add(new YandexRegion { Key = 7, StringName = "Кострома" });
            result.Add(new YandexRegion { Key = 8, StringName = "Курск" });
            result.Add(new YandexRegion { Key = 9, StringName = "Липецк" });
            result.Add(new YandexRegion { Key = 10, StringName = "Орел" });
            result.Add(new YandexRegion { Key = 11, StringName = "Рязань" });
            result.Add(new YandexRegion { Key = 12, StringName = "Смоленск" });
            result.Add(new YandexRegion { Key = 13, StringName = "Тамбов" });
            result.Add(new YandexRegion { Key = 14, StringName = "Тверь" });
            result.Add(new YandexRegion { Key = 15, StringName = "Тула" });
            result.Add(new YandexRegion { Key = 16, StringName = "Ярославль" });
            result.Add(new YandexRegion { Key = 17, StringName = "Северо-Запад" });
            result.Add(new YandexRegion { Key = 18, StringName = "Петрозаводск" });
            result.Add(new YandexRegion { Key = 19, StringName = "Сыктывкар" });
            result.Add(new YandexRegion { Key = 20, StringName = "Архангельск" });
            result.Add(new YandexRegion { Key = 21, StringName = "Вологда" });
            result.Add(new YandexRegion { Key = 22, StringName = "Калининград" });
            result.Add(new YandexRegion { Key = 23, StringName = "Мурманск" });
            result.Add(new YandexRegion { Key = 24, StringName = "Великий Новгород" });
            result.Add(new YandexRegion { Key = 25, StringName = "Псков" });
            result.Add(new YandexRegion { Key = 26, StringName = "Юг" });
            result.Add(new YandexRegion { Key = 28, StringName = "Махачкала" });
            result.Add(new YandexRegion { Key = 29, StringName = "------------" });
            result.Add(new YandexRegion { Key = 30, StringName = "Нальчик" });
            result.Add(new YandexRegion { Key = 33, StringName = "Владикавказ" });
            result.Add(new YandexRegion { Key = 35, StringName = "Краснодар" });
            result.Add(new YandexRegion { Key = 36, StringName = "Ставрополь" });
            result.Add(new YandexRegion { Key = 37, StringName = "Астрахань" });
            result.Add(new YandexRegion { Key = 38, StringName = "Волгоград" });
            result.Add(new YandexRegion { Key = 39, StringName = "Ростов-на-Дону" });
            result.Add(new YandexRegion { Key = 40, StringName = "Поволжье" });
            result.Add(new YandexRegion { Key = 41, StringName = "Йошкар-Ола" });
            result.Add(new YandexRegion { Key = 42, StringName = "Саранск" });
            result.Add(new YandexRegion { Key = 43, StringName = "Казань" });
            result.Add(new YandexRegion { Key = 44, StringName = "Ижевск" });
            result.Add(new YandexRegion { Key = 45, StringName = "Чебоксары" });
            result.Add(new YandexRegion { Key = 46, StringName = "Киров" });
            result.Add(new YandexRegion { Key = 47, StringName = "Нижний Новгород" });
            result.Add(new YandexRegion { Key = 48, StringName = "Оренбург" });
            result.Add(new YandexRegion { Key = 49, StringName = "Пенза" });
            result.Add(new YandexRegion { Key = 50, StringName = "Пермь" });
            result.Add(new YandexRegion { Key = 51, StringName = "Самара" });
            result.Add(new YandexRegion { Key = 52, StringName = "Урал" });
            result.Add(new YandexRegion { Key = 53, StringName = "Курган" });
            result.Add(new YandexRegion { Key = 54, StringName = "Екатеринбург" });
            result.Add(new YandexRegion { Key = 55, StringName = "Тюмень" });
            result.Add(new YandexRegion { Key = 56, StringName = "Челябинск" });
            result.Add(new YandexRegion { Key = 57, StringName = "Ханты-Мансийск" });
            result.Add(new YandexRegion { Key = 58, StringName = "Салехард" });
            result.Add(new YandexRegion { Key = 59, StringName = "Сибирь" });
            result.Add(new YandexRegion { Key = 62, StringName = "Красноярск" });
            result.Add(new YandexRegion { Key = 63, StringName = "Иркутск" });
            result.Add(new YandexRegion { Key = 64, StringName = "Кемерово" });
            result.Add(new YandexRegion { Key = 65, StringName = "Новосибирск" });
            result.Add(new YandexRegion { Key = 66, StringName = "Омск" });
            result.Add(new YandexRegion { Key = 67, StringName = "Томск" });
            result.Add(new YandexRegion { Key = 68, StringName = "Чита" });
            result.Add(new YandexRegion { Key = 73, StringName = "Дальний Восток" });
            result.Add(new YandexRegion { Key = 74, StringName = "Якутск" });
            result.Add(new YandexRegion { Key = 75, StringName = "Владивосток" });
            result.Add(new YandexRegion { Key = 76, StringName = "Хабаровск" });
            result.Add(new YandexRegion { Key = 77, StringName = "Благовещенск" });
            result.Add(new YandexRegion { Key = 78, StringName = "Петропавловск-Камчатский" });
            result.Add(new YandexRegion { Key = 79, StringName = "Магадан" });
            result.Add(new YandexRegion { Key = 80, StringName = "Южно-Сахалинск" });
            result.Add(new YandexRegion { Key = 84, StringName = "США" });
            result.Add(new YandexRegion { Key = 86, StringName = "Атланта" });
            result.Add(new YandexRegion { Key = 87, StringName = "Вашингтон" });
            result.Add(new YandexRegion { Key = 89, StringName = "Детройт" });
            result.Add(new YandexRegion { Key = 90, StringName = "Сан-Франциско" });
            result.Add(new YandexRegion { Key = 91, StringName = "Сиэтл" });
            result.Add(new YandexRegion { Key = 93, StringName = "Аргентина" });
            result.Add(new YandexRegion { Key = 94, StringName = "Бразилия" });
            result.Add(new YandexRegion { Key = 95, StringName = "Канада" });
            result.Add(new YandexRegion { Key = 96, StringName = "Германия" });
            result.Add(new YandexRegion { Key = 97, StringName = "Гейдельберг" });
            result.Add(new YandexRegion { Key = 98, StringName = "Кельн" });
            result.Add(new YandexRegion { Key = 99, StringName = "Мюнхен" });
            result.Add(new YandexRegion { Key = 100, StringName = "Франкфурт-на-Майне" });
            result.Add(new YandexRegion { Key = 101, StringName = "Штутгарт" });
            result.Add(new YandexRegion { Key = 102, StringName = "Великобритания" });
            result.Add(new YandexRegion { Key = 111, StringName = "Европа" });
            result.Add(new YandexRegion { Key = 113, StringName = "Австрия" });
            result.Add(new YandexRegion { Key = 114, StringName = "Бельгия" });
            result.Add(new YandexRegion { Key = 115, StringName = "Болгария" });
            result.Add(new YandexRegion { Key = 116, StringName = "Венгрия" });
            result.Add(new YandexRegion { Key = 117, StringName = "Литва" });
            result.Add(new YandexRegion { Key = 118, StringName = "Нидерланды" });
            result.Add(new YandexRegion { Key = 119, StringName = "Норвегия" });
            result.Add(new YandexRegion { Key = 120, StringName = "Польша" });
            result.Add(new YandexRegion { Key = 121, StringName = "Словакия" });
            result.Add(new YandexRegion { Key = 122, StringName = "Словения" });
            result.Add(new YandexRegion { Key = 123, StringName = "Финляндия" });
            result.Add(new YandexRegion { Key = 124, StringName = "Франция" });
            result.Add(new YandexRegion { Key = 125, StringName = "Чехия" });
            result.Add(new YandexRegion { Key = 126, StringName = "Швейцария" });
            result.Add(new YandexRegion { Key = 127, StringName = "Швеция" });
            result.Add(new YandexRegion { Key = 129, StringName = "Беер-Шева" });
            result.Add(new YandexRegion { Key = 130, StringName = "Иерусалим" });
            result.Add(new YandexRegion { Key = 131, StringName = "Тель-Авив" });
            result.Add(new YandexRegion { Key = 132, StringName = "Хайфа" });
            result.Add(new YandexRegion { Key = 134, StringName = "Китай" });
            result.Add(new YandexRegion { Key = 135, StringName = "Корея" });
            result.Add(new YandexRegion { Key = 137, StringName = "Япония" });
            result.Add(new YandexRegion { Key = 138, StringName = "Австралия и Океания" });
            result.Add(new YandexRegion { Key = 139, StringName = "Новая Зеландия" });
            result.Add(new YandexRegion { Key = 141, StringName = "Днепропетровск" });
            result.Add(new YandexRegion { Key = 142, StringName = "Донецк" });
            result.Add(new YandexRegion { Key = 143, StringName = "Киев" });
            result.Add(new YandexRegion { Key = 144, StringName = "Львов" });
            result.Add(new YandexRegion { Key = 145, StringName = "Одесса" });
            result.Add(new YandexRegion { Key = 146, StringName = "Симферополь" });
            result.Add(new YandexRegion { Key = 147, StringName = "Харьков" });
            result.Add(new YandexRegion { Key = 148, StringName = "Николаев" });
            result.Add(new YandexRegion { Key = 149, StringName = "Беларусь" });
            result.Add(new YandexRegion { Key = 153, StringName = "Брест" });
            result.Add(new YandexRegion { Key = 154, StringName = "Витебск" });
            result.Add(new YandexRegion { Key = 155, StringName = "Гомель" });
            result.Add(new YandexRegion { Key = 157, StringName = "Минск" });
            result.Add(new YandexRegion { Key = 157, StringName = "Минск" });
            result.Add(new YandexRegion { Key = 158, StringName = "Могилев" });
            result.Add(new YandexRegion { Key = 159, StringName = "Казахстан" });
            result.Add(new YandexRegion { Key = 162, StringName = "Алматы" });
            result.Add(new YandexRegion { Key = 163, StringName = "Астана" });
            result.Add(new YandexRegion { Key = 164, StringName = "Караганда" });
            result.Add(new YandexRegion { Key = 165, StringName = "Семей" });
            result.Add(new YandexRegion { Key = 166, StringName = "СНГ" });
            result.Add(new YandexRegion { Key = 167, StringName = "Азербайджан" });
            result.Add(new YandexRegion { Key = 168, StringName = "Армения" });
            result.Add(new YandexRegion { Key = 169, StringName = "Грузия" });
            result.Add(new YandexRegion { Key = 170, StringName = "Туркмения" });
            result.Add(new YandexRegion { Key = 171, StringName = "Узбекистан" });
            result.Add(new YandexRegion { Key = 172, StringName = "Уфа" });
            result.Add(new YandexRegion { Key = 177, StringName = "Берлин" });
            result.Add(new YandexRegion { Key = 178, StringName = "Гамбург" });
            result.Add(new YandexRegion { Key = 179, StringName = "Эстония" });
            result.Add(new YandexRegion { Key = 180, StringName = "Сербия" });
            result.Add(new YandexRegion { Key = 181, StringName = "Израиль" });
            result.Add(new YandexRegion { Key = 183, StringName = "Азия" });
            result.Add(new YandexRegion { Key = 187, StringName = "Украина" });
            result.Add(new YandexRegion { Key = 190, StringName = "Павлодар" });
            result.Add(new YandexRegion { Key = 191, StringName = "Брянск" });
            result.Add(new YandexRegion { Key = 192, StringName = "Владимир" });
            result.Add(new YandexRegion { Key = 193, StringName = "Воронеж" });
            result.Add(new YandexRegion { Key = 194, StringName = "Саратов" });
            result.Add(new YandexRegion { Key = 195, StringName = "Ульяновск" });
            result.Add(new YandexRegion { Key = 197, StringName = "Барнаул" });
            result.Add(new YandexRegion { Key = 198, StringName = "Улан-Удэ" });
            result.Add(new YandexRegion { Key = 200, StringName = "Лос-Анджелес" });
            result.Add(new YandexRegion { Key = 202, StringName = "Нью-Йорк" });
            result.Add(new YandexRegion { Key = 203, StringName = "Дания" });
            result.Add(new YandexRegion { Key = 204, StringName = "Испания" });
            result.Add(new YandexRegion { Key = 205, StringName = "Италия" });
            result.Add(new YandexRegion { Key = 206, StringName = "Латвия" });
            result.Add(new YandexRegion { Key = 207, StringName = "Киргизия" });
            result.Add(new YandexRegion { Key = 208, StringName = "Молдова" });
            result.Add(new YandexRegion { Key = 209, StringName = "Таджикистан" });
            result.Add(new YandexRegion { Key = 210, StringName = "Объединенные Арабские Эмираты" });
            result.Add(new YandexRegion { Key = 211, StringName = "Австралия" });
            result.Add(new YandexRegion { Key = 213, StringName = "Москва" });
            result.Add(new YandexRegion { Key = 213, StringName = "Москва" });
            result.Add(new YandexRegion { Key = 214, StringName = "Долгопрудный" });
            result.Add(new YandexRegion { Key = 215, StringName = "Дубна" });
            result.Add(new YandexRegion { Key = 216, StringName = "Зеленоград" });
            result.Add(new YandexRegion { Key = 217, StringName = "Пущино" });
            result.Add(new YandexRegion { Key = 219, StringName = "Черноголовка" });
            result.Add(new YandexRegion { Key = 221, StringName = "Чимкент" });
            result.Add(new YandexRegion { Key = 222, StringName = "Луганск" });
            result.Add(new YandexRegion { Key = 223, StringName = "Бостон" });
            result.Add(new YandexRegion { Key = 225, StringName = "Россия" });
            result.Add(new YandexRegion { Key = 235, StringName = "Магнитогорск" });
            result.Add(new YandexRegion { Key = 236, StringName = "Набережные Челны" });
            result.Add(new YandexRegion { Key = 237, StringName = "Новокузнецк" });
            result.Add(new YandexRegion { Key = 238, StringName = "Новочеркасск" });
            result.Add(new YandexRegion { Key = 239, StringName = "Сочи" });
            result.Add(new YandexRegion { Key = 240, StringName = "Тольятти" });
            result.Add(new YandexRegion { Key = 241, StringName = "Африка" });
            result.Add(new YandexRegion { Key = 245, StringName = "Арктика и Антарктика" });
            result.Add(new YandexRegion { Key = 246, StringName = "Греция" });
            result.Add(new YandexRegion { Key = 318, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 349, StringName = "Другие города региона" });
            result.Add(new YandexRegion { Key = 350, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 381, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 382, StringName = "Общероссийские" });
            result.Add(new YandexRegion { Key = 413, StringName = "Другие города региона" });
            result.Add(new YandexRegion { Key = 414, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 445, StringName = "Другие города региона" });
            result.Add(new YandexRegion { Key = 446, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 477, StringName = "Другие города региона" });
            result.Add(new YandexRegion { Key = 478, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 509, StringName = "Другие города региона" });
            result.Add(new YandexRegion { Key = 510, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 541, StringName = "Другие города региона" });
            result.Add(new YandexRegion { Key = 542, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 573, StringName = "Другие города региона" });
            result.Add(new YandexRegion { Key = 574, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 605, StringName = "Другие города региона" });
            result.Add(new YandexRegion { Key = 606, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 637, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 638, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 669, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 670, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 701, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 702, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 733, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 734, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 765, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 766, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 797, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 798, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 829, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 830, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 861, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 862, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 893, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 894, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 925, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 926, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 957, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 958, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 959, StringName = "Севастополь" });
            result.Add(new YandexRegion { Key = 960, StringName = "Запорожье" });
            result.Add(new YandexRegion { Key = 961, StringName = "Хмельницкий" });
            result.Add(new YandexRegion { Key = 962, StringName = "Херсон" });
            result.Add(new YandexRegion { Key = 963, StringName = "Винница" });
            result.Add(new YandexRegion { Key = 964, StringName = "Полтава" });
            result.Add(new YandexRegion { Key = 965, StringName = "Сумы" });
            result.Add(new YandexRegion { Key = 966, StringName = "Чернигов" });
            result.Add(new YandexRegion { Key = 967, StringName = "Обнинск" });
            result.Add(new YandexRegion { Key = 968, StringName = "Череповец" });
            result.Add(new YandexRegion { Key = 969, StringName = "Выборг" });
            result.Add(new YandexRegion { Key = 970, StringName = "Новороссийск" });
            result.Add(new YandexRegion { Key = 971, StringName = "Таганрог" });
            result.Add(new YandexRegion { Key = 972, StringName = "Дзержинск" });
            result.Add(new YandexRegion { Key = 973, StringName = "Сургут" });
            result.Add(new YandexRegion { Key = 974, StringName = "Находка" });
            result.Add(new YandexRegion { Key = 975, StringName = "Бийск" });
            result.Add(new YandexRegion { Key = 976, StringName = "Братск" });
            result.Add(new YandexRegion { Key = 977, StringName = "Крым" });
            result.Add(new YandexRegion { Key = 978, StringName = "Другие города региона" });
            result.Add(new YandexRegion { Key = 979, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 980, StringName = "Страны Балтии" });
            result.Add(new YandexRegion { Key = 981, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 982, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 983, StringName = "Турция" });
            result.Add(new YandexRegion { Key = 994, StringName = "Индия" });
            result.Add(new YandexRegion { Key = 995, StringName = "Таиланд" });
            result.Add(new YandexRegion { Key = 1004, StringName = "Ближний Восток" });
            result.Add(new YandexRegion { Key = 1048, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 1049, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 1054, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 1055, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 1056, StringName = "Египет" });
            result.Add(new YandexRegion { Key = 1058, StringName = "Туапсе" });
            result.Add(new YandexRegion { Key = 1091, StringName = "Нижневартовск" });
            result.Add(new YandexRegion { Key = 1092, StringName = "Назрань" });
            result.Add(new YandexRegion { Key = 1093, StringName = "Майкоп" });
            result.Add(new YandexRegion { Key = 1094, StringName = "Элиста" });
            result.Add(new YandexRegion { Key = 1095, StringName = "Абакан" });
            result.Add(new YandexRegion { Key = 1104, StringName = "Черкесск" });
            result.Add(new YandexRegion { Key = 1106, StringName = "Грозный" });
            result.Add(new YandexRegion { Key = 1107, StringName = "Анапа" });
            result.Add(new YandexRegion { Key = 10002, StringName = "Северная Америка" });
            result.Add(new YandexRegion { Key = 10003, StringName = "Южная Америка" });
            result.Add(new YandexRegion { Key = 10069, StringName = "Мальта" });
            result.Add(new YandexRegion { Key = 10083, StringName = "Хорватия" });
            result.Add(new YandexRegion { Key = 10174, StringName = "Санкт-Петербург и Ленинградская область" });
            result.Add(new YandexRegion { Key = 10176, StringName = "Ненецкий АО" });
            result.Add(new YandexRegion { Key = 10231, StringName = "Республика Алтай" });
            result.Add(new YandexRegion { Key = 10233, StringName = "Республика Тыва" });
            result.Add(new YandexRegion { Key = 10243, StringName = "Еврейская автономная область" });
            result.Add(new YandexRegion { Key = 10251, StringName = "Чукотский автономный округ" });
            result.Add(new YandexRegion { Key = 10274, StringName = "Гродно" });
            result.Add(new YandexRegion { Key = 10303, StringName = "Талдыкорган" });
            result.Add(new YandexRegion { Key = 10306, StringName = "Усть-Каменогорск" });
            result.Add(new YandexRegion { Key = 10313, StringName = "Кишинев" });
            result.Add(new YandexRegion { Key = 10313, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 10313, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 10314, StringName = "Бельцы" });
            result.Add(new YandexRegion { Key = 10315, StringName = "Бендеры" });
            result.Add(new YandexRegion { Key = 10317, StringName = "Тирасполь" });
            result.Add(new YandexRegion { Key = 10343, StringName = "Житомир" });
            result.Add(new YandexRegion { Key = 10345, StringName = "Ивано-Франковск" });
            result.Add(new YandexRegion { Key = 10347, StringName = "Кривой Рог" });
            result.Add(new YandexRegion { Key = 10355, StringName = "Ровно" });
            result.Add(new YandexRegion { Key = 10357, StringName = "Тернополь" });
            result.Add(new YandexRegion { Key = 10358, StringName = "Ужгород" });
            result.Add(new YandexRegion { Key = 10363, StringName = "Черкассы" });
            result.Add(new YandexRegion { Key = 10365, StringName = "Черновцы" });
            result.Add(new YandexRegion { Key = 10366, StringName = "Мариуполь" });
            result.Add(new YandexRegion { Key = 10367, StringName = "Мелитополь" });
            result.Add(new YandexRegion { Key = 10369, StringName = "Белая Церковь" });
            result.Add(new YandexRegion { Key = 10645, StringName = "Белгородская область" });
            result.Add(new YandexRegion { Key = 10649, StringName = "Старый Оскол" });
            result.Add(new YandexRegion { Key = 10650, StringName = "Брянская область" });
            result.Add(new YandexRegion { Key = 10656, StringName = "Александров" });
            result.Add(new YandexRegion { Key = 10658, StringName = "Владимирcкая область" });
            result.Add(new YandexRegion { Key = 10661, StringName = "Гусь-Хрустальный" });
            result.Add(new YandexRegion { Key = 10664, StringName = "Ковров" });
            result.Add(new YandexRegion { Key = 10668, StringName = "Муром" });
            result.Add(new YandexRegion { Key = 10671, StringName = "Суздаль" });
            result.Add(new YandexRegion { Key = 10672, StringName = "Воронежcкая область" });
            result.Add(new YandexRegion { Key = 10687, StringName = "Ивановская область" });
            result.Add(new YandexRegion { Key = 10693, StringName = "Калужская область" });
            result.Add(new YandexRegion { Key = 10699, StringName = "Костромская область" });
            result.Add(new YandexRegion { Key = 10705, StringName = "Курская область" });
            result.Add(new YandexRegion { Key = 10712, StringName = "Липецкая область" });
            result.Add(new YandexRegion { Key = 10716, StringName = "Балашиха" });
            result.Add(new YandexRegion { Key = 10719, StringName = "Видное" });
            result.Add(new YandexRegion { Key = 10723, StringName = "Дмитров" });
            result.Add(new YandexRegion { Key = 10725, StringName = "Домодедово" });
            result.Add(new YandexRegion { Key = 10733, StringName = "Клин" });
            result.Add(new YandexRegion { Key = 10734, StringName = "Коломна" });
            result.Add(new YandexRegion { Key = 10735, StringName = "Красногорск" });
            result.Add(new YandexRegion { Key = 10738, StringName = "Люберцы" });
            result.Add(new YandexRegion { Key = 10740, StringName = "Мытищи" });
            result.Add(new YandexRegion { Key = 10742, StringName = "Ногинск" });
            result.Add(new YandexRegion { Key = 10743, StringName = "Одинцово" });
            result.Add(new YandexRegion { Key = 10745, StringName = "Орехово-Зуево" });
            result.Add(new YandexRegion { Key = 10746, StringName = "Павловский Посад" });
            result.Add(new YandexRegion { Key = 10747, StringName = "Подольск" });
            result.Add(new YandexRegion { Key = 10748, StringName = "Пушкино" });
            result.Add(new YandexRegion { Key = 10750, StringName = "Раменское" });
            result.Add(new YandexRegion { Key = 10752, StringName = "Сергиев Посад" });
            result.Add(new YandexRegion { Key = 10754, StringName = "Серпухов" });
            result.Add(new YandexRegion { Key = 10755, StringName = "Солнечногорск" });
            result.Add(new YandexRegion { Key = 10756, StringName = "Ступино" });
            result.Add(new YandexRegion { Key = 10758, StringName = "Химки" });
            result.Add(new YandexRegion { Key = 10761, StringName = "Чехов" });
            result.Add(new YandexRegion { Key = 10765, StringName = "Щелково" });
            result.Add(new YandexRegion { Key = 10772, StringName = "Орловская область" });
            result.Add(new YandexRegion { Key = 10776, StringName = "Рязанская область" });
            result.Add(new YandexRegion { Key = 10795, StringName = "Смоленская область" });
            result.Add(new YandexRegion { Key = 10802, StringName = "Тамбовская область" });
            result.Add(new YandexRegion { Key = 10819, StringName = "Тверская область" });
            result.Add(new YandexRegion { Key = 10820, StringName = "Ржев" });
            result.Add(new YandexRegion { Key = 10830, StringName = "Новомосковск" });
            result.Add(new YandexRegion { Key = 10832, StringName = "Тульская область" });
            result.Add(new YandexRegion { Key = 10837, StringName = "Переславль" });
            result.Add(new YandexRegion { Key = 10838, StringName = "Ростов" });
            result.Add(new YandexRegion { Key = 10839, StringName = "Рыбинск" });
            result.Add(new YandexRegion { Key = 10840, StringName = "Углич" });
            result.Add(new YandexRegion { Key = 10841, StringName = "Ярославская область" });
            result.Add(new YandexRegion { Key = 10842, StringName = "Архангельская область" });
            result.Add(new YandexRegion { Key = 10849, StringName = "Северодвинск" });
            result.Add(new YandexRegion { Key = 10853, StringName = "Вологодская область" });
            result.Add(new YandexRegion { Key = 10857, StringName = "Калининградская область" });
            result.Add(new YandexRegion { Key = 10867, StringName = "Гатчина" });
            result.Add(new YandexRegion { Key = 10894, StringName = "Апатиты" });
            result.Add(new YandexRegion { Key = 10897, StringName = "Мурманская область" });
            result.Add(new YandexRegion { Key = 10904, StringName = "Новгородская область" });
            result.Add(new YandexRegion { Key = 10926, StringName = "Псковская область" });
            result.Add(new YandexRegion { Key = 10928, StringName = "Великие Луки" });
            result.Add(new YandexRegion { Key = 10933, StringName = "Республика Карелия" });
            result.Add(new YandexRegion { Key = 10937, StringName = "Сортавала" });
            result.Add(new YandexRegion { Key = 10939, StringName = "Республика Коми" });
            result.Add(new YandexRegion { Key = 10945, StringName = "Ухта" });
            result.Add(new YandexRegion { Key = 10946, StringName = "Астраханская область" });
            result.Add(new YandexRegion { Key = 10950, StringName = "Волгоградская область" });
            result.Add(new YandexRegion { Key = 10951, StringName = "Волжский" });
            result.Add(new YandexRegion { Key = 10987, StringName = "Армавир" });
            result.Add(new YandexRegion { Key = 10990, StringName = "Геленджик" });
            result.Add(new YandexRegion { Key = 10993, StringName = "Ейск" });
            result.Add(new YandexRegion { Key = 10995, StringName = "Краснодарский край" });
            result.Add(new YandexRegion { Key = 11004, StringName = "Республика Адыгея" });
            result.Add(new YandexRegion { Key = 11010, StringName = "Республика Дагестан" });
            result.Add(new YandexRegion { Key = 11012, StringName = "Республика Ингушетия" });
            result.Add(new YandexRegion { Key = 11013, StringName = "Республика Кабардино-Балкария" });
            result.Add(new YandexRegion { Key = 11015, StringName = "Республика Калмыкия" });
            result.Add(new YandexRegion { Key = 11020, StringName = "Карачаево-Черкесская Республика" });
            result.Add(new YandexRegion { Key = 11021, StringName = "Республика Северная Осетия-Алания" });
            result.Add(new YandexRegion { Key = 11024, StringName = "Чеченская Республика" });
            result.Add(new YandexRegion { Key = 11029, StringName = "Ростовская область" });
            result.Add(new YandexRegion { Key = 11036, StringName = "Волгодонск" });
            result.Add(new YandexRegion { Key = 11043, StringName = "Каменск-Шахтинский" });
            result.Add(new YandexRegion { Key = 11053, StringName = "Шахты" });
            result.Add(new YandexRegion { Key = 11057, StringName = "Ессентуки" });
            result.Add(new YandexRegion { Key = 11062, StringName = "Кисловодск" });
            result.Add(new YandexRegion { Key = 11063, StringName = "Минеральные Воды" });
            result.Add(new YandexRegion { Key = 11064, StringName = "Невинномысск" });
            result.Add(new YandexRegion { Key = 11067, StringName = "Пятигорск" });
            result.Add(new YandexRegion { Key = 11069, StringName = "Ставропольский край" });
            result.Add(new YandexRegion { Key = 11070, StringName = "Кировская область" });
            result.Add(new YandexRegion { Key = 11071, StringName = "Кирово-Чепецк" });
            result.Add(new YandexRegion { Key = 11077, StringName = "Республика Марий Эл" });
            result.Add(new YandexRegion { Key = 11079, StringName = "Нижегородская область" });
            result.Add(new YandexRegion { Key = 11080, StringName = "Арзамас" });
            result.Add(new YandexRegion { Key = 11083, StringName = "Саров" });
            result.Add(new YandexRegion { Key = 11084, StringName = "Оренбургская область" });
            result.Add(new YandexRegion { Key = 11091, StringName = "Орск" });
            result.Add(new YandexRegion { Key = 11095, StringName = "Пензенская область" });
            result.Add(new YandexRegion { Key = 11108, StringName = "Пермский край" });
            result.Add(new YandexRegion { Key = 11110, StringName = "Соликамск" });
            result.Add(new YandexRegion { Key = 11111, StringName = "Республика Башкортостан" });
            result.Add(new YandexRegion { Key = 11114, StringName = "Нефтекамск" });
            result.Add(new YandexRegion { Key = 11115, StringName = "Салават" });
            result.Add(new YandexRegion { Key = 11116, StringName = "Стерлитамак" });
            result.Add(new YandexRegion { Key = 11117, StringName = "Республика Мордовия" });
            result.Add(new YandexRegion { Key = 11119, StringName = "Татарстан" });
            result.Add(new YandexRegion { Key = 11121, StringName = "Альметьевск" });
            result.Add(new YandexRegion { Key = 11122, StringName = "Бугульма" });
            result.Add(new YandexRegion { Key = 11123, StringName = "Елабуга" });
            result.Add(new YandexRegion { Key = 11125, StringName = "Зеленодольск" });
            result.Add(new YandexRegion { Key = 11127, StringName = "Нижнекамск" });
            result.Add(new YandexRegion { Key = 11129, StringName = "Чистополь" });
            result.Add(new YandexRegion { Key = 11131, StringName = "Самарская область" });
            result.Add(new YandexRegion { Key = 11132, StringName = "Жигулевск" });
            result.Add(new YandexRegion { Key = 11139, StringName = "Сызрань" });
            result.Add(new YandexRegion { Key = 11143, StringName = "Балаково" });
            result.Add(new YandexRegion { Key = 11146, StringName = "Саратовская область" });
            result.Add(new YandexRegion { Key = 11147, StringName = "Энгельс" });
            result.Add(new YandexRegion { Key = 11148, StringName = "Удмуртская республика" });
            result.Add(new YandexRegion { Key = 11150, StringName = "Глазов" });
            result.Add(new YandexRegion { Key = 11152, StringName = "Сарапул" });
            result.Add(new YandexRegion { Key = 11153, StringName = "Ульяновская область" });
            result.Add(new YandexRegion { Key = 11155, StringName = "Димитровград" });
            result.Add(new YandexRegion { Key = 11156, StringName = "Чувашская республика" });
            result.Add(new YandexRegion { Key = 11158, StringName = "Курганская область" });
            result.Add(new YandexRegion { Key = 11162, StringName = "Свердловская область" });
            result.Add(new YandexRegion { Key = 11164, StringName = "Каменск-Уральский" });
            result.Add(new YandexRegion { Key = 11168, StringName = "Нижний Тагил" });
            result.Add(new YandexRegion { Key = 11170, StringName = "Новоуральск" });
            result.Add(new YandexRegion { Key = 11171, StringName = "Первоуральск" });
            result.Add(new YandexRegion { Key = 11173, StringName = "Ишим" });
            result.Add(new YandexRegion { Key = 11175, StringName = "Тобольск" });
            result.Add(new YandexRegion { Key = 11176, StringName = "Тюменская область" });
            result.Add(new YandexRegion { Key = 11193, StringName = "Ханты-Мансийский АО" });
            result.Add(new YandexRegion { Key = 11202, StringName = "Златоуст" });
            result.Add(new YandexRegion { Key = 11212, StringName = "Миасс" });
            result.Add(new YandexRegion { Key = 11214, StringName = "Озерск" });
            result.Add(new YandexRegion { Key = 11217, StringName = "Сатка" });
            result.Add(new YandexRegion { Key = 11218, StringName = "Снежинск" });
            result.Add(new YandexRegion { Key = 11225, StringName = "Челябинская область" });
            result.Add(new YandexRegion { Key = 11232, StringName = "Ямало-Ненецкий АО" });
            result.Add(new YandexRegion { Key = 11235, StringName = "Алтайский край" });
            result.Add(new YandexRegion { Key = 11251, StringName = "Рубцовск" });
            result.Add(new YandexRegion { Key = 11256, StringName = "Ангарск" });
            result.Add(new YandexRegion { Key = 11266, StringName = "Иркутская область" });
            result.Add(new YandexRegion { Key = 11273, StringName = "Усть-Илимск" });
            result.Add(new YandexRegion { Key = 11282, StringName = "Кемеровская область" });
            result.Add(new YandexRegion { Key = 11287, StringName = "Междуреченск" });
            result.Add(new YandexRegion { Key = 11291, StringName = "Прокопьевск" });
            result.Add(new YandexRegion { Key = 11302, StringName = "Ачинск" });
            result.Add(new YandexRegion { Key = 11306, StringName = "Кайеркан" });
            result.Add(new YandexRegion { Key = 11309, StringName = "Красноярский край" });
            result.Add(new YandexRegion { Key = 11311, StringName = "Норильск" });
            result.Add(new YandexRegion { Key = 11314, StringName = "Бердск" });
            result.Add(new YandexRegion { Key = 11316, StringName = "Новосибирская область" });
            result.Add(new YandexRegion { Key = 11318, StringName = "Омская область" });
            result.Add(new YandexRegion { Key = 11319, StringName = "Горно-Алтайск" });
            result.Add(new YandexRegion { Key = 11330, StringName = "Республика Бурятия" });
            result.Add(new YandexRegion { Key = 11333, StringName = "Кызыл" });
            result.Add(new YandexRegion { Key = 11340, StringName = "Республика Хакасия" });
            result.Add(new YandexRegion { Key = 11341, StringName = "Саяногорск" });
            result.Add(new YandexRegion { Key = 11351, StringName = "Северск" });
            result.Add(new YandexRegion { Key = 11353, StringName = "Томская область" });
            result.Add(new YandexRegion { Key = 11374, StringName = "Белогорск" });
            result.Add(new YandexRegion { Key = 11375, StringName = "Амурская область" });
            result.Add(new YandexRegion { Key = 11391, StringName = "Тында" });
            result.Add(new YandexRegion { Key = 11393, StringName = "Биробиджан" });
            result.Add(new YandexRegion { Key = 11398, StringName = "Камчатский край" });
            result.Add(new YandexRegion { Key = 11403, StringName = "Магаданская область" });
            result.Add(new YandexRegion { Key = 11409, StringName = "Приморский край" });
            result.Add(new YandexRegion { Key = 11426, StringName = "Уссурийск" });
            result.Add(new YandexRegion { Key = 11443, StringName = "Республика Саха (Якутия)" });
            result.Add(new YandexRegion { Key = 11450, StringName = "Сахалинская область" });
            result.Add(new YandexRegion { Key = 11453, StringName = "Комсомольск-на-Амуре" });
            result.Add(new YandexRegion { Key = 11457, StringName = "Хабаровский край" });
            result.Add(new YandexRegion { Key = 11458, StringName = "Анадырь" });
            result.Add(new YandexRegion { Key = 11464, StringName = "Керчь" });
            result.Add(new YandexRegion { Key = 11470, StringName = "Ялта" });
            result.Add(new YandexRegion { Key = 20040, StringName = "Выкса" });
            result.Add(new YandexRegion { Key = 20044, StringName = "Кстово" });
            result.Add(new YandexRegion { Key = 20086, StringName = "Железногорск" });
            result.Add(new YandexRegion { Key = 20221, StringName = "Кировоград" });
            result.Add(new YandexRegion { Key = 20222, StringName = "Луцк" });
            result.Add(new YandexRegion { Key = 20258, StringName = "Сатис" });
            result.Add(new YandexRegion { Key = 20271, StringName = "Мексика" });
            result.Add(new YandexRegion { Key = 20273, StringName = "Актобе" });
            result.Add(new YandexRegion { Key = 20523, StringName = "Электросталь" });
            result.Add(new YandexRegion { Key = 20529, StringName = "Львовская область" });
            result.Add(new YandexRegion { Key = 20530, StringName = "Закарпатская область" });
            result.Add(new YandexRegion { Key = 20531, StringName = "Тернопольская область" });
            result.Add(new YandexRegion { Key = 20532, StringName = "Ивано-Франковская область" });
            result.Add(new YandexRegion { Key = 20533, StringName = "Черновицкая область" });
            result.Add(new YandexRegion { Key = 20534, StringName = "Ровенская область" });
            result.Add(new YandexRegion { Key = 20535, StringName = "Хмельницкая область" });
            result.Add(new YandexRegion { Key = 20536, StringName = "Донецкая область" });
            result.Add(new YandexRegion { Key = 20537, StringName = "Днепропетровская область" });
            result.Add(new YandexRegion { Key = 20538, StringName = "Харьковская область" });
            result.Add(new YandexRegion { Key = 20539, StringName = "Запорожская область" });
            result.Add(new YandexRegion { Key = 20540, StringName = "Луганская область" });
            result.Add(new YandexRegion { Key = 20541, StringName = "Одесская область" });
            result.Add(new YandexRegion { Key = 20542, StringName = "Херсонская область" });
            result.Add(new YandexRegion { Key = 20543, StringName = "Николаевская область" });
            result.Add(new YandexRegion { Key = 20544, StringName = "Киевская область" });
            result.Add(new YandexRegion { Key = 20545, StringName = "Винницкая область" });
            result.Add(new YandexRegion { Key = 20546, StringName = "Черкасская область" });
            result.Add(new YandexRegion { Key = 20547, StringName = "Житомирская область" });
            result.Add(new YandexRegion { Key = 20548, StringName = "Кировоградская область" });
            result.Add(new YandexRegion { Key = 20549, StringName = "Полтавская область" });
            result.Add(new YandexRegion { Key = 20550, StringName = "Волынская область" });
            result.Add(new YandexRegion { Key = 20551, StringName = "Черниговская область" });
            result.Add(new YandexRegion { Key = 20552, StringName = "Сумская область" });
            result.Add(new YandexRegion { Key = 20554, StringName = "Краматорск" });
            result.Add(new YandexRegion { Key = 20571, StringName = "Жуковский" });
            result.Add(new YandexRegion { Key = 20574, StringName = "Кипр" });
            result.Add(new YandexRegion { Key = 20674, StringName = "Троицк" });
            result.Add(new YandexRegion { Key = 20728, StringName = "Королёв" });
            result.Add(new YandexRegion { Key = 20809, StringName = "Кокшетау" });
            result.Add(new YandexRegion { Key = 21609, StringName = "Кременчуг" });
            result.Add(new YandexRegion { Key = 21610, StringName = "Черногория" });
            result.Add(new YandexRegion { Key = 21621, StringName = "Реутов" });
            result.Add(new YandexRegion { Key = 21622, StringName = "Железнодорожный" });
            result.Add(new YandexRegion { Key = 21777, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21778, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21779, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21780, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21781, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21782, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21783, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21784, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21785, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21786, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21787, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21788, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21789, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21790, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21791, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21792, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21793, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21794, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21796, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21797, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21798, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21799, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21800, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21801, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21802, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21803, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21804, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21805, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21806, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21807, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21808, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21809, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21810, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21811, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21812, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21813, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21814, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21815, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21816, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21817, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21818, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21819, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21825, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21826, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21827, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21828, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21829, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21830, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21831, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21832, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21833, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21834, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21835, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21836, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21837, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21838, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21839, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21840, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21841, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21842, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21843, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21844, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21845, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21846, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21847, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21848, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21849, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21850, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21852, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21853, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21854, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21855, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21856, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21857, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21858, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21859, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21860, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21861, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21862, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21863, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21864, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21865, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21866, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21867, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21868, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21869, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21870, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21871, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21872, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21873, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21874, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21875, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21876, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21877, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21878, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21879, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21880, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21881, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21882, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21883, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21884, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21885, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21886, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21887, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21888, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21889, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21890, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21891, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21892, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21893, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21894, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21895, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21896, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21897, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21898, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21899, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21900, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21901, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21902, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21903, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21904, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21905, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21906, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21907, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21908, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21909, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21910, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21911, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21912, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21913, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21914, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21915, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21916, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21917, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21918, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21919, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21920, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21921, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21922, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21923, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21924, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21925, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21926, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21927, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21928, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21929, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21930, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21931, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21932, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21933, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21934, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21935, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21936, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21937, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21938, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21939, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21940, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21941, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21942, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 21943, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 21949, StringName = "Забайкальский край" });
            result.Add(new YandexRegion { Key = 24876, StringName = "Макеевка" });
            result.Add(new YandexRegion { Key = 26034, StringName = "Жодино" });
            result.Add(new YandexRegion { Key = 29386, StringName = "Абхазия" });
            result.Add(new YandexRegion { Key = 29387, StringName = "Южная Осетия" });
            result.Add(new YandexRegion { Key = 29403, StringName = "Акмолинская область" });
            result.Add(new YandexRegion { Key = 29404, StringName = "Актюбинская область" });
            result.Add(new YandexRegion { Key = 29406, StringName = "Алматинская область" });
            result.Add(new YandexRegion { Key = 29407, StringName = "Атырауская область" });
            result.Add(new YandexRegion { Key = 29408, StringName = "Восточно-Казахстанская область" });
            result.Add(new YandexRegion { Key = 29409, StringName = "Жамбылская область" });
            result.Add(new YandexRegion { Key = 29410, StringName = "Западно-Казахстанская область" });
            result.Add(new YandexRegion { Key = 29411, StringName = "Карагандинская область" });
            result.Add(new YandexRegion { Key = 29412, StringName = "Костанайская область" });
            result.Add(new YandexRegion { Key = 29413, StringName = "Кызылординская область" });
            result.Add(new YandexRegion { Key = 29414, StringName = "Мангистауская область" });
            result.Add(new YandexRegion { Key = 29415, StringName = "Павлодарская область" });
            result.Add(new YandexRegion { Key = 29416, StringName = "Северо-Казахстанская область" });
            result.Add(new YandexRegion { Key = 29417, StringName = "Южно-Казахстанская область" });
            result.Add(new YandexRegion { Key = 29629, StringName = "Могилевская область" });
            result.Add(new YandexRegion { Key = 29630, StringName = "Минская область" });
            result.Add(new YandexRegion { Key = 29631, StringName = "Гомельская область" });
            result.Add(new YandexRegion { Key = 29632, StringName = "Брестская область" });
            result.Add(new YandexRegion { Key = 29633, StringName = "Витебская область" });
            result.Add(new YandexRegion { Key = 29634, StringName = "Гродненская область" });
            result.Add(new YandexRegion { Key = 33883, StringName = "Комрат" });
            result.Add(new YandexRegion { Key = 101852, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 101853, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 101854, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 101855, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 101856, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 101857, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 101858, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 101859, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 101860, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 101861, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 101862, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 101863, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 101864, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 101865, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102444, StringName = "Северный Кавказ" });
            result.Add(new YandexRegion { Key = 102445, StringName = "Другие города региона" });
            result.Add(new YandexRegion { Key = 102446, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102450, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102451, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102452, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102453, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102454, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102455, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102456, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102457, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102458, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102459, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102460, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102461, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102462, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102464, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102465, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102466, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102467, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102468, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102469, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102470, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102471, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102472, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102473, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102475, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102476, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102477, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102478, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102479, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102480, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102481, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102482, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102483, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102484, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102485, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102486, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102487, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102489, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102490, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102491, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102492, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102493, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102494, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102495, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102496, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102497, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102498, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102499, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102500, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102501, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102502, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102503, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102504, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102505, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102506, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102507, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102508, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102509, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102510, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102511, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102512, StringName = "Прочее" });
            result.Add(new YandexRegion { Key = 102513, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102514, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102515, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102516, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102517, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102518, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102519, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102520, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102521, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102522, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102523, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102524, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102525, StringName = "Универсальное" });
            result.Add(new YandexRegion { Key = 102526, StringName = "Универсальное" });



            return result;
            #endregion
        }



    }
    public class APICredentials // Пользователь и Логин к API
    {
        public string User { get; set; }
        public string Key { get; set; }

    }


    public class YandexSearchQuery
    {
        private APICredentials _APICredentials { get; set; } // Обьект идентификации пользователь и токен
        private YandexRegion _region { get; set; }
        private string _query { get; set; } //Запрос
        private int _page { get; set; } //Страница
        public string _found { get; set; }
        public string _error { get; set; }
        private Stream _responseStream { get; set; } //Ответ
        private RequestMethodEnum _requestMethod { get; set; } //Метод запроса
        public YandexSearchQuery(string query, int page, APICredentials APICred, YandexRegion region, RequestMethodEnum? requestMethod)
        {

            if (!String.IsNullOrEmpty(query.Trim()))
            {
                _query = query;
                if (region != null) //Если запрос с регионом
                {
                    _region = region;
                }
                else
                {
                    _region = new YandexRegion();
                    _region.Key = -1;
                    _region.StringName = "Региональная привязка отсутсвует";
                }

            }
            _page = page;
            _APICredentials = APICred;
            if (requestMethod != null)
            {
                _requestMethod = (RequestMethodEnum)requestMethod;

            }
            else
            {   //По умолчанию отправляем запрос POST
                _requestMethod = RequestMethodEnum.POST;
            }
            if (_requestMethod == RequestMethodEnum.POST)
            {
                this._responseStream = ResponseStreamPOST();


            }
            else if (_requestMethod == RequestMethodEnum.GET)
            {
                this._responseStream = ResponseStreamGET();

            }


        }
        public XDocument GetResponseToXDocument()
        {

            XmlReader xmlReader = XmlReader.Create(this._responseStream);
            return XDocument.Load(xmlReader);

        }
        public string GetResponseToString()
        {
            using (StreamReader ResponseStreamReader = new StreamReader(this._responseStream))
            {
                return ResponseStreamReader.ReadToEnd();
            }
        }
        private Stream ResponseStreamPOST()
        {

            ServicePointManager.Expect100Continue = false;
            string regionquery = "";

            if (_region.Key != -1)
            {
                regionquery = "lr=" + _region.Key + "&";


            }
            /* Адрес для совершения запроса, полученный при регистрации IP,
            в него уже забит логин и ключ API.*/
            string url = @"http://xmlsearch.yandex.ru/xmlsearch?" + regionquery + "user=" + _APICredentials.User + "&key=" + _APICredentials.Key;





            //if (_region.Key != -1)
            //{
            //    long swift = 11000000; //Смещение для регионов

            //    long swiftedregion = swift +  _region.Key;

            //    regionquery = " cat:" + swiftedregion.ToString();


            //}
            // Текст запроса в формате XML
            string command =
              @"<?xml version=""1.0"" encoding=""UTF-8""?>  
                      <request>  
                       <query>" + _query.ToString() + @"</query>
<sortby order=""descending"" priority=""no"">rlv</sortby>
   <maxpassages>2</maxpassages>
        <page>" + _page.ToString() + @"</page>
                       < groupings>
                         <groupby attr=""d""
                                mode=""deep""
                                groups-on-page=""100""
                                docs-in-group=""1"" />  
                       </groupings>
  <nocache/>
                      </request>";


            byte[] bytes = Encoding.UTF8.GetBytes(command);
            // Объект, с помощью которого будем отсылать запрос и получать ответ.
            HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            HttpWebRequest.DefaultCachePolicy = policy;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);


            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "text/xml";
            // Пишем наш XML-запрос в поток
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            // Получаем ответ
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responsestream = response.GetResponseStream();
            return responsestream;


        }
        private Stream ResponseStreamGET()
        {
            string regionquery = "";
            ServicePointManager.Expect100Continue = false;
            if (_region.Key != -1)
            {
                regionquery = "lr=" + _region.Key + "&";


            }
            string completeUrl = String.Format("http://xmlsearch.yandex.ru/xmlsearch?{0}query={1}&groupby=attr%3Dd.mode%3Ddeep.groups-on-page%3D100.docs-in-group%3D1&page={2}&user={3}&key={4}", regionquery, _query, _page, _APICredentials.User, _APICredentials.Key);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(completeUrl);
            //Получение ответа.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responsestream = response.GetResponseStream();
            return responsestream;


        }

        public List<YaSearchResult> GetResponseToList()
        {

            //Лист структур YaSearchResult, который метод в итоге возвращает.
            List<YaSearchResult> ret = new List<YaSearchResult>();

            XmlReader xmlReader = XmlReader.Create(this._responseStream);
            XDocument response = XDocument.Load(xmlReader);
            _error = GetError(response);
            //из полученного XML'я выдираем все элементы с именем "group" - это результаты поиска
            var groupQuery = from gr in response.Elements().
                          Elements("response").
                          Elements("results").
                          Elements("grouping").
                          Elements("group")
                             select gr;
            //
            _found = Getfound(response);
            //каждый элемент group преобразовывается в объект SearchResult
            for (int i = 0; i < groupQuery.Count(); i++)
            {
                int position = i + 1;
                string urlQuery = GetValue(groupQuery.ElementAt(i), "url");
                string titleQuery = GetValue(groupQuery.ElementAt(i), "title");
                string descriptionQuery = GetValue(groupQuery.ElementAt(i), "headline");
                string indexedTimeQuery = GetValue(groupQuery.ElementAt(i), "modtime");
                string cacheUrlQuery = GetValue(groupQuery.ElementAt(i),
                                "saved-copy-url");
                string domain = GetValue(groupQuery.ElementAt(i),
                                "domain");
                ret.Add(new YaSearchResult(position, urlQuery, cacheUrlQuery, titleQuery, descriptionQuery, indexedTimeQuery, domain));
            }

            return ret;
        }
        public static string Getfound(XDocument response)
        {
            try { return response.Element("found-docs-human").Name.ToString(); }
            catch { return String.Empty; }
        }

        public static string GetError(XDocument response)
        {
            try { return response.Element("error").Attribute("code").Value; }
            catch { return String.Empty; }
        }
        public static string GetValue(XElement group, string name)
        {
            try
            {
                return group.Element("doc").Element(name).Value;
            }
            //это если в результате нету элемента с каким то именем,
            //то будет вместо значащей строчки возвращаться пустая.
            catch
            {
                return string.Empty;
            }
        }


    }
}


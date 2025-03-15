using E_Shop.Domain.Models.AddressModels;

namespace E_Shop.Infra.Data.Seeds
{
    public static class CitySeeds
    {
        public static List<City> ApplicationCities { get; } =
        [
            #region AzarbayejanSharghi
            new() { StateId = 1, Id = 1, CityName = "تبریز" },
            new() { StateId = 1, Id = 2, CityName = "مراغه" },
            new() { StateId = 1, Id = 3, CityName = "مرند" },
            new() { StateId = 1, Id = 4, CityName = "اهر" },
            new() { StateId = 1, Id = 5, CityName = "بناب" },
            new() { StateId = 1, Id = 6, CityName = "شبستر" },
            new() { StateId = 1, Id = 7, CityName = "سراب" },
            new() { StateId = 1, Id = 8, CityName = "میانه" },
            new() { StateId = 1, Id = 9, CityName = "هشترود" },
            new() { StateId = 1, Id = 10, CityName = "آذرشهر" },
            #endregion
           
            #region AzarbayejanGharbi
            new() { StateId = 2, Id = 11, CityName = "ارومیه" },
            new() { StateId = 2, Id = 12, CityName = "خوی" },
            new() { StateId = 2, Id = 13, CityName = "مهاباد" },
            new() { StateId = 2, Id = 14, CityName = "میاندوآب" },
            new() { StateId = 2, Id = 15, CityName = "نقده" },
            new() { StateId = 2, Id = 16, CityName = "سلماس" },
            new() { StateId = 2, Id = 17, CityName = "پیرانشهر" },
            new() { StateId = 2, Id = 18, CityName = "شاهین‌دژ" },
            new() { StateId = 2, Id = 19, CityName = "سردشت" },
            #endregion
           
            #region Ardebil
            new() { StateId = 3, Id = 20, CityName = "اردبیل" },
            new() { StateId = 3, Id = 21, CityName = "پارس‌آباد" },
            new() { StateId = 3, Id = 22, CityName = "مشگین‌شهر" },
            new() { StateId = 3, Id = 23, CityName = "خلخال" },
            new() { StateId = 3, Id = 24, CityName = "گرمی" },
            new() { StateId = 3, Id = 25, CityName = "بیله‌سوار" },
            new() { StateId = 3, Id = 26, CityName = "نمین" },
            #endregion
           
            #region Esfahan
            new() { StateId = 4, Id = 27, CityName = "اصفهان" },
            new() { StateId = 4, Id = 28, CityName = "کاشان" },
            new() { StateId = 4, Id = 29, CityName = "شهرضا" },
            new() { StateId = 4, Id = 30, CityName = "خمینی‌شهر" },
            new() { StateId = 4, Id = 31, CityName = "نجف‌آباد" },
            new() { StateId = 4, Id = 32, CityName = "فلاورجان" },
            new() { StateId = 4, Id = 33, CityName = "نائین" },
            new() { StateId = 4, Id = 34, CityName = "اردستان" },
            new() { StateId = 4, Id = 35, CityName = "نطنز" },
            new() { StateId = 4, Id = 36, CityName = "گلپایگان" },
            #endregion
           
            #region Alborz
            new() { StateId = 5, Id = 37, CityName = "کرج" },
            new() { StateId = 5, Id = 38, CityName = "نظرآباد" },
            new() { StateId = 5, Id = 39, CityName = "ساوجبلاغ" },
            new() { StateId = 5, Id = 40, CityName = "اشتهارد" },
            #endregion
            
            #region Ilam
            new() { StateId = 6, Id = 41, CityName = "ایلام" },
            new() { StateId = 6, Id = 42, CityName = "مهران" },
            new() { StateId = 6, Id = 43, CityName = "دهلران" },
            new() { StateId = 6, Id = 44, CityName = "آبدانان" },
            new() { StateId = 6, Id = 45, CityName = "دره‌شهر" },
            new() { StateId = 6, Id = 46, CityName = "ارکواز" },
            #endregion
            
            #region Bushehr
            new() { StateId = 7, Id = 47, CityName = "بوشهر" },
            new() { StateId = 7, Id = 48, CityName = "برازجان" },
            new() { StateId = 7, Id = 49, CityName = "دیلم" },
            new() { StateId = 7, Id = 50, CityName = "گناوه" },
            new() { StateId = 7, Id = 51, CityName = "جم" },
            new() { StateId = 7, Id = 52, CityName = "کنگان" },
            new() { StateId = 7, Id = 53, CityName = "دشتستان" },
            #endregion
            
            #region Tehran
            new() { StateId = 8, Id = 54, CityName = "تهران" },
            new() { StateId = 8, Id = 55, CityName = "ری" },
            new() { StateId = 8, Id = 56, CityName = "شمیرانات" },
            new() { StateId = 8, Id = 57, CityName = "اسلامشهر" },
            new() { StateId = 8, Id = 58, CityName = "ورامین" },
            new() { StateId = 8, Id = 59, CityName = "شهریار" },
            new() { StateId = 8, Id = 60, CityName = "دماوند" },
            new() { StateId = 8, Id = 61, CityName = "ملارد" },
            #endregion
            
            #region ChaharmahalBakhtiari
            new() { StateId = 9, Id = 62, CityName = "شهرکرد" },
            new() { StateId = 9, Id = 63, CityName = "بروجن" },
            new() { StateId = 9, Id = 64, CityName = "لردگان" },
            new() { StateId = 9, Id = 65, CityName = "فرخ‌شهر" },
            new() { StateId = 9, Id = 66, CityName = "فارسان" },
            new() { StateId = 9, Id = 67, CityName = "کیار" },
            new() { StateId = 9, Id = 68, CityName = "اردل" },
            new() { StateId = 9, Id = 69, CityName = "سامان" },
            new() { StateId = 9, Id = 70, CityName = "کوهرنگ" },
            #endregion
            
            #region KhorasanShomali
            new() { StateId = 10, Id = 71, CityName = "بجنورد" },
            new() { StateId = 10, Id = 72, CityName = "شیروان" },
            new() { StateId = 10, Id = 73, CityName = "اسفراین" },
            new() { StateId = 10, Id = 74, CityName = "مانه و سملقان" },
            #endregion
            
            #region KhorasanJonoobi
            new() { StateId = 11, Id = 75, CityName = "بیرجند" },
            new() { StateId = 11, Id = 76, CityName = "قائن" },
            new() { StateId = 11, Id = 77, CityName = "فردوس" },
            new() { StateId = 11, Id = 78, CityName = "طبس" },
            new() { StateId = 11, Id = 79, CityName = "نهبندان" },
            new() { StateId = 11, Id = 80, CityName = "سرایان" },
            #endregion
            
            #region KhorasanRazavi
            new() { StateId = 12, Id = 81, CityName = "مشهد" },
            new() { StateId = 12, Id = 82, CityName = "نیشابور" },
            new() { StateId = 12, Id = 83, CityName = "سبزوار" },
            new() { StateId = 12, Id = 84, CityName = "تربت‌حیدریه" },
            new() { StateId = 12, Id = 85, CityName = "کاشمر" },
            new() { StateId = 12, Id = 86, CityName = "قوچان" },
            new() { StateId = 12, Id = 87, CityName = "گناباد" },
            new() { StateId = 12, Id = 88, CityName = "چناران" },
            #endregion
            
            #region Khuzestan
            new() { StateId = 13, Id = 89, CityName = "اهواز" },
            new() { StateId = 13, Id = 90, CityName = "آبادان" },
            new() { StateId = 13, Id = 91, CityName = "دزفول" },
            new() { StateId = 13, Id = 92, CityName = "اندیمشک" },
            new() { StateId = 13, Id = 93, CityName = "خرمشهر" },
            new() { StateId = 13, Id = 94, CityName = "شوشتر" },
            new() { StateId = 13, Id = 95, CityName = "بهبهان" },
            new() { StateId = 13, Id = 96, CityName = "شوش" },
            new() { StateId = 13, Id = 97, CityName = "ماهشهر" },
            #endregion
            
            #region Zanjan
            new() { StateId = 14, Id = 98, CityName = "زنجان" },
            new() { StateId = 14, Id = 99, CityName = "ابهر" },
            new() { StateId = 14, Id = 100, CityName = "خدابنده" },
            new() { StateId = 14, Id = 101, CityName = "ماه‌نشان" },
            new() { StateId = 14, Id = 102, CityName = "طارم" },
            new() { StateId = 14, Id = 103, CityName = "سلطانیه" },
            #endregion
            
            #region Semnan
            new() { StateId = 15, Id = 104, CityName = "سمنان" },
            new() { StateId = 15, Id = 105, CityName = "شاهرود" },
            new() { StateId = 15, Id = 106, CityName = "دامغان" },
            new() { StateId = 15, Id = 107, CityName = "گرمسار" },
            new() { StateId = 15, Id = 108, CityName = "مهدیشهر" },
            new() { StateId = 15, Id = 109, CityName = "آرادان" },
            #endregion
            
            #region SistanBaluchestan
            new() { StateId = 16, Id = 110, CityName = "زاهدان" },
            new() { StateId = 16, Id = 111, CityName = "زابل" },
            new() { StateId = 16, Id = 112, CityName = "ایرانشهر" },
            new() { StateId = 16, Id = 113, CityName = "چابهار" },
            new() { StateId = 16, Id = 114, CityName = "سراوان" },
            new() { StateId = 16, Id = 115, CityName = "نیک‌شهر" },
            new() { StateId = 16, Id = 116, CityName = "کنارک" },
            #endregion
           
            #region Fars
            new() { StateId = 17, Id = 117, CityName = "شیراز" },
            new() { StateId = 17, Id = 118, CityName = "مرودشت" },
            new() { StateId = 17, Id = 119, CityName = "جهرم" },
            new() { StateId = 17, Id = 120, CityName = "کازرون" },
            new() { StateId = 17, Id = 121, CityName = "فسا" },
            new() { StateId = 17, Id = 122, CityName = "داراب" },
            new() { StateId = 17, Id = 123, CityName = "آباده" },
            new() { StateId = 17, Id = 124, CityName = "اقلید" },
            #endregion
            
            #region Qazvin
            new() { StateId = 18, Id = 125, CityName = "قزوین" },
            new() { StateId = 18, Id = 126, CityName = "تاکستان" },
            new() { StateId = 18, Id = 127, CityName = "آبیک" },
            new() { StateId = 18, Id = 128, CityName = "الوند" },
            new() { StateId = 18, Id = 129, CityName = "بوئین‌زهرا" },
            #endregion
            
            #region Qom
            new() { StateId = 19, Id = 130, CityName = "قم" },
            #endregion
            
            #region Kurdistan
            new() { StateId = 20, Id = 131, CityName = "سنندج" },
            new() { StateId = 20, Id = 132, CityName = "مریوان" },
            new() { StateId = 20, Id = 133, CityName = "سقز" },
            new() { StateId = 20, Id = 134, CityName = "بانه" },
            new() { StateId = 20, Id = 135, CityName = "بیجار" },
            new() { StateId = 20, Id = 136, CityName = "دیواندره" },
            #endregion
            
            #region Kerman
            new() { StateId = 21, Id = 137, CityName = "کرمان" },
            new() { StateId = 21, Id = 138, CityName = "سیرجان" },
            new() { StateId = 21, Id = 139, CityName = "رفسنجان" },
            new() { StateId = 21, Id = 140, CityName = "جیرفت" },
            new() { StateId = 21, Id = 141, CityName = "بم" },
            new() { StateId = 21, Id = 142, CityName = "زرند" },
            new() { StateId = 21, Id = 143, CityName = "بافت" },
            #endregion
            
            #region Kermanshah
            new() { StateId = 22, Id = 144, CityName = "کرمانشاه" },
            new() { StateId = 22, Id = 145, CityName = "اسلام‌آباد" },
            new() { StateId = 22, Id = 146, CityName = "سرپل ذهاب" },
            new() { StateId = 22, Id = 147, CityName = "هرسین" },
            new() { StateId = 22, Id = 148, CityName = "گیلانغرب" },
            new() { StateId = 22, Id = 149, CityName = "کنگاور" },
            #endregion
            
            #region KohgiluyehBoyerahmad
            new() { StateId = 23, Id = 150, CityName = "یاسوج" },
            new() { StateId = 23, Id = 151, CityName = "گچساران" },
            new() { StateId = 23, Id = 152, CityName = "دهدشت" },
            new() { StateId = 23, Id = 153, CityName = "دوگنبدان" },
            #endregion
            
            #region Golestan
            new() { StateId = 24, Id = 154, CityName = "گرگان" },
            new() { StateId = 24, Id = 155, CityName = "گنبد کاووس" },
            new() { StateId = 24, Id = 156, CityName = "علی‌آباد" },
            new() { StateId = 24, Id = 157, CityName = "بندرترکمن" },
            new() { StateId = 24, Id = 158, CityName = "آق‌قلا" },
            #endregion
            
            #region Gilan
            new() { StateId = 25, Id = 159, CityName = "رشت" },
            new() { StateId = 25, Id = 160, CityName = "بندرانزلی" },
            new() { StateId = 25, Id = 161, CityName = "لاهیجان" },
            new() { StateId = 25, Id = 162, CityName = "لنگرود" },
            new() { StateId = 25, Id = 163, CityName = "تالش" },
            new() { StateId = 25, Id = 164, CityName = "آستارا" },
            #endregion
            
            #region Lorestan
            new() { StateId = 26, Id = 165, CityName = "خرم‌آباد" },
            new() { StateId = 26, Id = 166, CityName = "بروجرد" },
            new() { StateId = 26, Id = 167, CityName = "دورود" },
            new() { StateId = 26, Id = 168, CityName = "الیگودرز" },
            new() { StateId = 26, Id = 169, CityName = "کوهدشت" },
            #endregion
            
            #region Mazandaran
            new() { StateId = 27, Id = 170, CityName = "ساری" },
            new() { StateId = 27, Id = 171, CityName = "آمل" },
            new() { StateId = 27, Id = 172, CityName = "بابل" },
            new() { StateId = 27, Id = 173, CityName = "قائم‌شهر" },
            new() { StateId = 27, Id = 174, CityName = "تنکابن" },
            new() { StateId = 27, Id = 175, CityName = "رامسر" },
            #endregion
            
            #region Markazi
            new() { StateId = 28, Id = 176, CityName = "اراک" },
            new() { StateId = 28, Id = 177, CityName = "ساوه" },
            new() { StateId = 28, Id = 178, CityName = "خمین" },
            new() { StateId = 28, Id = 179, CityName = "محلات" },
            new() { StateId = 28, Id = 180, CityName = "دلیجان" },
            #endregion
            
            #region Hormozgan
            new() { StateId = 29, Id = 181, CityName = "بندرعباس" },
            new() { StateId = 29, Id = 182, CityName = "قشم" },
            new() { StateId = 29, Id = 183, CityName = "میناب" },
            new() { StateId = 29, Id = 184, CityName = "بندرلنگه" },
            new() { StateId = 29, Id = 185, CityName = "جاسک" },
            #endregion
            
            #region Hamedan
            new() { StateId = 30, Id = 186, CityName = "همدان" },
            new() { StateId = 30, Id = 187, CityName = "ملایر" },
            new() { StateId = 30, Id = 188, CityName = "نهاوند" },
            new() { StateId = 30, Id = 189, CityName = "اسدآباد" },
            new() { StateId = 30, Id = 190, CityName = "تویسرکان" },
            #endregion
            
            #region Yazd
            new() { StateId = 31, Id = 191, CityName = "یزد" },
            new() { StateId = 31, Id = 192, CityName = "اردکان" },
            new() { StateId = 31, Id = 193, CityName = "میبد" },
            new() { StateId = 31, Id = 194, CityName = "بافق" },
            new() { StateId = 31, Id = 195, CityName = "تفت" },
            new() { StateId = 31, Id = 196, CityName = "مهریز" },
            #endregion
    ];
    }

}

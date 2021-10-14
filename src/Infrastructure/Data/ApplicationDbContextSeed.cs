using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContextSeed : IdentityDbContext
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (await dbContext.Categories.AnyAsync() || await dbContext.Products.AnyAsync()) return;

            var cat1 = new Category() { CategoryName = "Çekirdek Kahve" };
            var cat2 = new Category() { CategoryName = "Kapsül Kahve" };
            var cat3 = new Category() { CategoryName = "Ekipman" };
            dbContext.AddRange(cat1, cat2, cat3);

            var p1 = new Product() { ProductName = "Starbucks House Blend Çekirdek Kahve 250 gr", ProductCode = "P001C01", Description = "Ne çok yumuşak, ne de çok yoğun lezzette olan orta derecede kavrulmuş kahvedir,damak zevki ikisinin ortasında olan kahve severler için idealdir. Yumuşak içimli ve dengeli bu kahveyi gün boyunca tercih edebilirsiniz.", Price = 97.46m, PictureUri = "1.jpg", Category = cat1 };

            var p2 = new Product() { ProductName = "Starbucks Veranda Blend Çekirdek Kahve 250 Gr", ProductCode = "P002C01", Description = "Starbucks Veranda %100 Arabica Çekirdek Kahve 250 Gr Tadım Notları: Yumuşak içimli ve zarif Bu özel seçilmiş Latin Amerika çekirdeklerini daha kısa süre kavurarak kakao ve kavrulmuş fındık lezzetlerinin ortaya çıkmasını sağladık. Hafif içimli bu kahvemizin tamamlayıcı lezzetleri fındık ve sütlü çikolatadır.", Price = 106.40m, PictureUri = "2.jpg", Category = cat1 };

            var p3 = new Product() { ProductName = "Starbucks Blonde Espresso Roast Filtre Kahve 250 gr", ProductCode = "P003C01", Description = "Espresso bazlı içeceklerimizin kalbi, hafif içim ile karşınızda!Latin Amerika ve Asya/Pasifik bölgelerinin harmanıdır.Bu yoğun lezzetli ve dolgun gövdeli harman süt ile mükemmel uyum sağladığından, tüm espresso bazlı içeceklerimizin hazırlanmasında kullanılmaktadır. Yumuşak içimli, karamel lezzeti sunan, keskinliği az olan bir kahvedir.", Price = 120.70m, PictureUri = "3.jpg", Category = cat1 };

            var p4 = new Product() { ProductName = "Starbucks Decaf Espresso RoastStarbucks Decaf Espresso Roast Kahve 250 Gr", ProductCode = "P004C01", Description = "Bu yoğun lezzetli ve dolgun gövdeli harman süt ile mükemmel uyum sağladığından, tüm espresso bazlı içeceklerimizin hazırlanmasında kullanılmaktadır. Yumuşak içimli, karamel lezzeti sunan, keskinliği az olan bir kahvedir.", Price = 104.50m, PictureUri = "4.jpg", Category = cat1 };

            var p5 = new Product() { ProductName = "Starbucks Pike Place Roast Filtre Kahve 250 gr", ProductCode = "P005C01", Description = "French press için çekilmiş. Starbucks'ın en güzel kahvelerinden biridir. Yumuşak içimli olan bu ürünü hem sıcak hem de soğuk tüketebilirsiniz. Türkiye'de yeni satılmasına rağmen bir çok kahve sever tarafından tüketilmektedir.", Price = 106.46m, PictureUri = "5.jpg", Category = cat1 };

            var p6 = new Product() { ProductName = "Starbucks Pike Place Roast Kapsül", ProductCode = "P006C02", Description = "Starbucks Pike Place Roast Starbucks Pike Place Roast 10 Adet", Price = 95.25m, PictureUri = "6.jpg", Category = cat2 };

            var p7 = new Product() { ProductName = "Starbucks Espresso Roast Kapsül", ProductCode = "P007C02", Description = "Starbucks Espresso Roast Kapsül Kahve Starbucks Espresso Roast Kapsül Kahve 10 Adet 53 gr", Price = 103.46m, PictureUri = "7.jpg", Category = cat2 };
            var p8 = new Product() { ProductName = "Starbucks Single Origin Coffe Colombia Kapsül", ProductCode = "P008C02", Description = "Calvin Klein Wavy K9U23546 is an amazing and eye-catching Ladies watch. Case is made out of Stainless Steel while the dial colour is Silver.", Price = 99.00m, PictureUri = "8.jpg", Category = cat2 };

            var p9 = new Product() { ProductName = "Chemex Ahşap Tutacaklı 6 Cup", ProductCode = "P009C03", Description = "Ahşap tutacak sayesinde rahatça servis edebilirsiniz.6 kupalık hacmi sayesinde sevdiklerinizle beraber kullanabilirsiniz. Borosilikat cam teknolojisi kimyasalların camda kalmasını engeller. Şık tasarımı ile basit bir kullanım sağlar.Ocakta ısıtılabilir.", Price = 205.00m, PictureUri = "9.jpg", Category = cat3 };

            var p10 = new Product() { ProductName = "Hario V60 02 Seramik Beyaz Dripper", ProductCode = "P010C03", Description = "Temizlemesi ve kullanması oldukça basit olan bu ürün ile azami 4 kişi için Kahve demleyebilirsiniz. V60 Kahve ile suyu her noktada buluşturan spiralli yapısı ile Kahvenin aromasının en iyi şekilde kupanıza gelmesini sağlar.", Price = 226.80m, PictureUri = "10.jpg", Category = cat3 };

            var p11 = new Product() { ProductName = "Fossil Watch ES4824", ProductCode = "P011C03", Description = "Chemex ile en mükemmel kahveyi hazırlayabilmek için doğru kalınlık, geçirgenlik ve laboratuvar teknolojisi ile üretilmiş beyaz chemex filtresi herhangi bir koku, tad ve kimyasal içermez. 6 - 8 Cup modelleri için uygundur. 100 adet beyaz Chemex filtre kağıdı içerir.", Price = 119.90m, PictureUri = "11.jpg", Category = cat3 };

            dbContext.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 );

            await dbContext.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Concrete
{
    public class Messages
    {
        //Category Messages
        public const string CategoryAdded = "Kategori başarıyla eklendi.";
        public const string CategoryDeleted = "Kategori başarıyla silindi.";
        public const string CategoryUpdated = "Kategori başarıyla güncellendi.";

        //Company Messages
        public const string CompanyAdded = "Şirket başarıyla eklendi.";
        public const string CompanyDeleted = "Şirket başarıyla silindi";
        public const string CompanyUpdated = "Şirket başarıyla güncellendi.";

        //PaymentType Messages
        public const string PaymentTypeAdded = "Ödeme türü başarıyla eklendi.";
        public const string PaymentTypeDeleted = "Ödeme türü başarıyla silindi.";
        public const string PaymentTypeUpdated = "Ödeme türü başarıyla güncellendi.";

        //Receipt Messages
        public const string ReceiptAdded = "Fatura başarıyla eklendi.";
        public const string ReceiptDeleted = "Fatura başarıyla silindi.";
        public const string ReceiptUpdated = "Fatura başarıyla güncellendi.";

        //User Messages
        public const string UserAdded = "Kullanıcı başarıyla eklendi.";
        public const string UserDeleted = "Kullanıcı başarıyla silindi.";
        public const string UserUpdated = "Kullanıcı başarıyla güncellendi.";
        public const string UserRegistered = "Başarıyla kayıt olundu.";
        public const string UserLogin = "Başarıyla giriş yapıldı.";
        public const string UserNotFound = "Kullanıcı bulunamadı.";
        public const string UserPasswordError = "Şifre hatalı.";
        public const string UserAlreadyExists = "Kullanıcı sistemde kayıtlı.";
        public const string AccessTokenCreated = "Access Token başarıyla oluşturuldu.";

        //AuthorizationMessages
        public const string AuthorizationDenied = "Gerekli yetki bulunamadı.";
    }
}

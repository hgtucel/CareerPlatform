using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contants
{
    public static class Messages
    {
        public static string Added = "Başarıyla eklendi";
        public static string Deleted = "Başarıyla silindi";
        public static string Updated = "Başarıyla güncellendi";

        public static string RegisterOk = "Başarıyla kayıt olundu.";
        public static string UserAlreadyExists = "Böyle bir kullanıcı zaten mevcut";
        public static string LoginOk = "Başarıyla giriş yapıldı.";
        public static string UserNotFound = "Bu şekilde bir üyelik bulunamadı.";
        public static string PasswordError = "Şifre hatalı.";
        public static string AccessTokenCreated = "Access Token oluşturuldu";

        public static string BeforeRecourse = "Daha önce bu ilana başvurdunuz";
        public static string OwnerAccess = "Bu size ait değil ve buna yetkili değilsiniz.";

        public static string SearchNull = "Boş girilemez. Lütfen aramak istediğiniz anahtar kelimeyi yazın.";
    }
}

# Hafta - 4

# İş Yönetim Sistemi

-	Bir işyerindeki iş takiplerinin yapılabilmesi için geliştirilecek uygulamadır
-	Program, küçük veya orta ölçekli işyerlerine hitap edecektir
-	İlgili kişiler tarafından işlerin açılması ve işi alan veya iş atanan kişinin işi çözmesi beklenmektedir.



## İsterler 

Detayların tamamı [bu dosyada](https://github.com/GelecekVarlik-FullStack-Bootcamp/odev-hafta4-dnet-AdylshaY/blob/main/Odev_4.docx) bulunmaktadır. Ana başlıklar aşağıdaki gibidir.

- Personel Giriş
- Personel Kayıt
- Personal Parola Değiştirme
- Yeni İş Talebi Oluşturma
- İşleri Listeleme
- İş Atama
- İş Üzerinden Yazışma
- İşin Detay Bilgilerinin Görüntülenmesi

## Proje Hakkında
**Kullanılan Teknolojiler:**   .NET Core 5, MsSql

Veritabanı MsSql Server Management Studio üzerinden oluşturuldu ve daha sonra veritabanı
projeye bağlandı. 

Projede 3 adet yetki seviyesi bulunuyor, bunlar: Admin - Manager - Employee

Yetki hiyerarşisi: Admin > Manager > Employee

Projeye MsSql Server Management Studio üzerinden bir adet admin hesabı oluşturuldu. Bu hesap
ile diğer kullanıcılar eklenebiliyor. Daha sonra bu kullanıcılar kendi bilgileri ile giriş
yapabiliyor. Burada JWT kullanıldı. 

Manager'lar sisteme yeni talep oluşturabiliyor. Oluşturulan bu talepleri Employee yetkisine
sahip çalışanlar görüntüleyebiliyor ve henüz işi alan yoksa kendilerine işi alabiliyor. 

Manager ve Admin yetkisine sahip kişiler sisteme yeni departman, iş, kullanıcı ekleyebiliyor,
güncelleyebilir ve silebiliyor. 

Employee yetkisine sahip kişiler sadece işleri görüntüleyebiliyor ve bu işleri alabiliyor. 

Şifre değiştirirken önceki şifrenin kontrolü yapılıyor.

![Projeye ait ekran görüntüsü]("/Screenshots/CodeMetricResults.png")
![Projeye ait ekran görüntüsü]("/Screenshots/SwaggerSS.png")





## Proje Sahibi
**Adylsha Yumayev**

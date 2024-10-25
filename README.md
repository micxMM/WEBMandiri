aplikasi ini merupakan 2 bagian microservice

https://github.com/micxMM/APITestMandiri  - Rest API
https://github.com/micxMM/WEBMandiri - Web Razor

dengan database sql server 
table

user(
id PK identity
nama
umur
domisili
pekerjaan )

transaksi (
id pk identity
iduser FK user(id)
namabarang
jumlah
)


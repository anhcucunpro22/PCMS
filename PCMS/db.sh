dotnet ef dbcontext scaffold -o Models -f -d "Data Source= DESKTOP-CURC7TC\\LEHUY; Initial Catalog=PhotoCMS; User Id= sa; password = 123;Trusted_Connection=False;TrustServerCertificate=True" "Microsoft.EntityFrameworkCore.SqlServer"


dotnet ef: Đây là lệnh dùng để chạy các công cụ Entity Framework Core 
từ dòng lệnh.

dbcontext scaffold: Đây là phần của lệnh để chỉ định rằng chúng ta muốn sử dụng 
công cụ Scaffold để tạo ra DbContext và các entity class từ cơ sở dữ liệu.

-o Models: Đây là tùy chọn để chỉ định thư mục đầu ra (output) cho các entity class 
được tạo ra từ cơ sở dữ liệu. Trong trường hợp này, các entity class sẽ được đặt trong 
thư mục "Models".

-f: Đây là tùy chọn để ghi đè lên các file đã tồn tại trong thư mục đầu ra nếu có.

-d: Đây là tùy chọn để chỉ định chuỗi kết nối đến cơ sở dữ liệu mà chúng ta 
muốn tạo ra DbContext và các entity class từ.
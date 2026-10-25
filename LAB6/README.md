# LAB6 - QUẢN LÝ PHÒNG KHÁM BỆNH

## 1. Giới thiệu

LAB6 là bài thực hành môn **Phát triển phần mềm hướng đối tượng (OOSD)**, xây dựng ứng dụng **Quản lý phòng khám bệnh** bằng **C# Windows Forms**.

Ứng dụng hỗ trợ quản lý thông tin bệnh nhân, hồ sơ bệnh án, đăng ký khám, phiếu khám, lệ phí, thanh toán viện phí, theo dõi sau điều trị, tra cứu hồ sơ và thống kê hoạt động của phòng khám.

Dữ liệu được lưu trữ và quản lý bằng **SQL Server LocalDB**, sử dụng cơ sở dữ liệu `QL_KhamBenh`. Chương trình sử dụng ADO.NET để kết nối và thao tác với cơ sở dữ liệu.

## 2. Công nghệ sử dụng

- C#
- Windows Forms
- .NET Framework
- SQL Server LocalDB
- SQL Server Management Studio (SSMS)
- Visual Studio
- Git/GitHub

## 3. Chức năng chính

**Quản lý hồ sơ bệnh án**

- Quản lý thông tin đăng ký của bệnh nhân.
- Lập và quản lý hồ sơ bệnh án.
- Theo dõi thời hạn hiệu lực của hồ sơ.
- Tra cứu hồ sơ theo mã hồ sơ, CCCD, số BHYT hoặc họ tên.
- Xem lịch sử khám bệnh của hồ sơ đang chọn.

**Quản lý khám bệnh**

- Quản lý phiếu khám bệnh.
- Ghi nhận ngày giờ khám, bác sĩ, khoa khám, triệu chứng và kết luận.
- Phân biệt khám bệnh và khám sức khỏe định kỳ.
- Tra cứu thông tin các lần khám.

**Quản lý lệ phí và thanh toán**

- Quản lý việc đóng lệ phí.
- Ghi nhận hóa đơn và tiền thuốc, tiền xét nghiệm.
- Tính tổng viện phí.
- Ghi nhận hình thức thanh toán và ngày xuất viện.
- Chỉ thực hiện theo dõi sau điều trị đối với hóa đơn đã thanh toán.

**Theo dõi sau điều trị**

- Ghi nhận diễn biến bệnh.
- Ghi nhận phản ứng phụ.
- Đánh giá hiệu quả điều trị.
- Lưu thông tin trách nhiệm bác sĩ.
- Xem lịch sử theo dõi của từng hóa đơn.

**Thống kê**

- Thống kê số hồ sơ bệnh án mới.
- Thống kê lượt khám bệnh và lượt khám sức khỏe định kỳ.
- Tổng hợp doanh thu lệ phí và viện phí.
- Thống kê số lượt khám theo khoa trong khoảng thời gian được chọn.

**Quản lý tài khoản và phân quyền**

- Đăng nhập hệ thống.
- Phân quyền sử dụng chức năng theo vai trò người dùng được cấu hình trong ứng dụng.

## 4. Cấu trúc thư mục

```text
LAB6/
├── README.md
└── LAB6/
    ├── LAB6.sln
    └── LAB6/
        ├── App.config
        ├── Program.cs
        ├── Db.cs
        ├── UI.cs
        ├── Session.cs
        ├── FrmLogin.cs
        ├── FrmDangKyHoSo.cs
        ├── FrmTraCuuHoSo.cs
        ├── FrmThongKe.cs
        ├── FrmThanhToan.cs
        ├── FrmTheoDoi.cs
        └── ...
```

_Lưu ý: Cấu trúc trên minh họa các tệp chính dựa trên mã nguồn hiện có. Hãy điều chỉnh danh sách cho khớp với cấu trúc thực tế của repository._

## 5. Cách tải và chạy chương trình

### 5.1. Tải source code

Clone repository:

```bash
git 
cd LAB_OOSD/LAB6
```

Nếu mã nguồn LAB6 nằm trong thư mục con khác, hãy điều chỉnh đường dẫn theo cấu trúc thực tế của repository.

### 5.2. Mở project

1. Mở Visual Studio.
2. Chọn **File → Open → Project/Solution**.
3. Chọn file `LAB6.sln`.
4. Chờ Visual Studio tải project và các thành phần liên quan.

### 5.3. Tạo cơ sở dữ liệu

1. Mở SQL Server Management Studio (SSMS).
2. Kết nối với SQL Server LocalDB bằng server name:

   ```text
   (localdb)\MSSQLLocalDB
   ```

3. Mở file SQL tạo cơ sở dữ liệu của dự án.
4. Thực thi script để tạo database `QL_KhamBenh`, các bảng và dữ liệu mẫu.
5. Kiểm tra database `QL_KhamBenh` đã xuất hiện và các bảng cần thiết đã được tạo thành công.

**Lưu ý:** Tên file SQL phải được xác định theo file thực tế trong repository.

### 5.4. Cấu hình kết nối LocalDB

Trong file `Db.cs`, cấu hình chuỗi kết nối như sau:

```csharp
public static string ConnectionString { get; set; } =
    @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=QL_KhamBenh;Integrated Security=True;TrustServerCertificate=True;";
```

Lớp `Db` sử dụng chuỗi kết nối này để thực hiện các thao tác truy vấn, thêm, sửa, xóa và lấy dữ liệu từ cơ sở dữ liệu.

Nếu dự án sử dụng `App.config` để lưu chuỗi kết nối, cấu hình có thể được khai báo như sau:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <connectionStrings>
        <add name="QL_KhamBenh"
             connectionString="Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=QL_KhamBenh;Integrated Security=True;TrustServerCertificate=True;"
             providerName="System.Data.SqlClient" />
    </connectionStrings>
</configuration>
```

Lưu ý: Mã nguồn `Db.cs` hiện tại đọc trực tiếp thuộc tính `ConnectionString`, không tự động lấy chuỗi kết nối từ `App.config`. Vì vậy, cần đảm bảo cấu hình thực tế mà chương trình sử dụng trỏ đến đúng database.

### 5.5. Build và chạy chương trình

Trong Visual Studio:

1. Chọn project WinForms làm **Startup Project**.
2. Chọn **Build → Build Solution**.
3. Kiểm tra và sửa các lỗi biên dịch nếu có.
4. Nhấn **F5** hoặc chọn **Debug → Start Debugging** để chạy chương trình.

Nếu cấu hình đúng, ứng dụng Quản lý phòng khám bệnh sẽ khởi động và hiển thị màn hình đầu tiên được thiết lập trong chương trình.

## 6. Kiểm tra kết nối cơ sở dữ liệu

Lớp `Db` cung cấp phương thức `TestConnection()` để kiểm tra kết nối đến LocalDB.

Có thể gọi phương thức này để kiểm tra và hiển thị lỗi nếu không kết nối được:

```csharp
string error;

if (Db.TestConnection(out error))
{
    MessageBox.Show("Kết nối cơ sở dữ liệu thành công.");
}
else
{
    MessageBox.Show("Không thể kết nối cơ sở dữ liệu: " + error);
}
```

## 7. Lưu ý

- Cần cài đặt Visual Studio và thành phần SQL Server LocalDB tương thích với dự án.
- Phải tạo database `QL_KhamBenh` trước khi chạy ứng dụng.
- Kiểm tra tên database và chuỗi kết nối trong `Db.cs` nếu chương trình không kết nối được.
- Đảm bảo các bảng và dữ liệu cần thiết đã được tạo đúng theo script SQL của dự án.
- Nếu sử dụng `System.Data.SqlClient`, cần bảo đảm project đang nhắm đến framework hỗ trợ thư viện này hoặc đã cài đặt package phù hợp.
- Tên đăng nhập, mật khẩu mẫu và quyền sử dụng cần căn cứ vào dữ liệu thực tế của dự án; không nên sử dụng tài khoản giả định khi chưa kiểm tra script SQL hoặc mã nguồn đăng nhập.

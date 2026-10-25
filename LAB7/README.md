# LAB7 - Quản lý nhân sự và tiền lương

Bài thực hành môn Phát triển phần mềm hướng đối tượng (OOSD).

- **Sinh viên:** Phan Nguyễn Gia Huy
- **MSSV:** 1250080076
- **Lớp:** _(điền lớp của bạn)_

## Dự án này làm gì?

Đây là một ứng dụng desktop viết bằng C# Windows Forms để quản lý nhân sự và tiền lương cho một doanh nghiệp. Ứng dụng đi theo hành trình của một nhân viên: nhận hồ sơ ứng tuyển, cho thử việc, ký hợp đồng chính thức, rồi theo dõi chấm công, tính lương, khen thưởng và kỷ luật.

Dữ liệu nằm trong SQL Server (database `QL_NhanSu`), còn code truy cập dữ liệu dùng ADO.NET.

## Công nghệ

- C#, Windows Forms (.NET Framework)
- Visual Studio 2022
- SQL Server 2025 (bản Standard Developer) và SSMS 22
- ADO.NET với `Microsoft.Data.SqlClient`
- Git/GitHub

## Hiện tại đã làm được gì?

Code được chia làm ba lớp cho dễ tìm: `Forms` là giao diện, `Services` chứa phần xử lý và truy vấn, `Data` lo việc kết nối database. Các class dữ liệu như `ChucVu` hay `HoSoUngTuyen` nằm trong `Models.cs`.

Các màn hình có sẵn trong project:

| Màn hình | Dùng để |
|---|---|
| `FrmMain` | Form chính, menu để mở các chức năng khác |
| `FrmChucVu` | Quản lý chức vụ và phụ cấp chức vụ |
| `FrmPhongBan` | Quản lý phòng ban |
| `FrmNhanVien` | Quản lý hồ sơ nhân viên |
| `FrmHoSoUngTuyen` | Quản lý hồ sơ ứng tuyển |
| `FrmQuyetDinhTuyenDung` | Lập quyết định tuyển dụng và thử việc |

Những phần còn lại như hợp đồng, bảo hiểm, chấm công, bảng lương, thưởng phạt và thống kê thì mới nằm trong thiết kế (xem mục "Hệ thống dự định hỗ trợ" bên dưới), chưa có màn hình riêng.

## Hệ thống dự định hỗ trợ

**Tuyển dụng và thử việc**
- Nhận hồ sơ ứng tuyển, ghi rõ phòng ban cần người.
- Lập quyết định tuyển dụng gồm thời gian thử việc, lương thử việc và các điều khoản.
- Theo dõi kết quả thử việc. Chỉ người đạt mới được ký hợp đồng chính thức.

**Hợp đồng lao động**
- Có hợp đồng ngắn hạn và dài hạn, lưu ngày ký, ngày hiệu lực, thời hạn và lịch sử.
- Hợp đồng dài hạn không có ngày kết thúc, và bắt buộc phải có cả hồ sơ BHYT lẫn BHXH.

**Quyết định nhân sự**
- Bổ nhiệm, điều chuyển, đổi chức vụ, tăng lương, phụ cấp (lương, chức vụ, độc hại) đều phải có quyết định đi kèm và được lưu lại lịch sử.
- Người ký quyết định là Giám đốc đang tại chức vào thời điểm ký.

**Bảo hiểm**
- Quản lý hồ sơ BHYT, BHXH và tính các khoản phải trừ vào lương.

**Chấm công và giờ phụ trội**
- Chấm công theo nhân viên, ngày và ca; lập kế hoạch phân ca theo tuần.
- Phiếu phụ trội cho tăng ca, ngày lễ, ngày nghỉ. Giờ phụ trội được tính bằng 1,5 lần giờ bình thường.

**Tính lương**
- Lương tháng được tính từ quyết định lương, quyết định chức vụ, bảng chấm công, phiếu phụ trội, cộng với tiền thưởng và trừ bảo hiểm, tiền phạt.
- Có thể xem lại lịch sử lương của từng người.

**Khen thưởng và kỷ luật**
- Khen thưởng hoặc kỷ luật cho cá nhân hay cả một phòng ban.
- Thưởng được chi qua phiếu chi. Tiền phạt thu qua phiếu thu hoặc trừ thẳng vào lương.
- Thưởng lễ, thưởng cuối năm và lương tháng 13 cần quyết định do Giám đốc ký.

**Thống kê và báo cáo**
- Báo cáo nhân viên mới, danh sách theo phòng ban/chức vụ/loại hợp đồng, biến động hợp đồng, chấm công, chi phí lương, bảo hiểm, thưởng phạt. Lọc được theo khoảng thời gian.

**Tài khoản và phân quyền**
- Đăng nhập, quản lý tài khoản, phân quyền theo vai trò để kiểm soát ai được lập, sửa và duyệt quyết định.

## Các quy tắc nghiệp vụ cần nhớ

- Người mới phải có quyết định tuyển dụng, trong đó ghi rõ phòng ban, thời gian và lương thử việc.
- Phải đủ 18 tuổi khi bắt đầu thử việc.
- Chỉ kết luận "đạt" thử việc khi đã hết thời gian thử việc. Không đạt thì chuyển sang trạng thái nghỉ việc.
- Hợp đồng chính thức chỉ được ký khi đã đạt thử việc, và ngày hiệu lực phải sau ngày kết thúc thử việc.
- Không ký hợp đồng chồng lên một hợp đồng còn hiệu lực.
- Lưu hợp đồng, lưu hồ sơ bảo hiểm và chuyển nhân viên sang chính thức phải nằm trong cùng một transaction, để lỗi giữa chừng không làm dữ liệu lệch nhau.
- Hợp đồng dài hạn: không có ngày kết thúc, bắt buộc có BHYT và BHXH.
- Tăng lương hay bổ nhiệm đều phải có quyết định và phải lưu lịch sử.
- Giờ phụ trội tính hệ số 1,5.
- Người ký quyết định được xác định theo Giám đốc đang giữ chức tại ngày quyết định hoặc ngày ký, dựa trên quyết định chức vụ có hiệu lực gần nhất.

## Cấu trúc thư mục

```text
LAB_OOSD/
├── README.md
└── LAB7/
    ├── LAB7.sln
    ├── QL_NhanSu.sql
    └── QuanLyNhanSu/
        ├── App.config
        ├── Program.cs
        ├── Models.cs
        ├── Data/
        │   └── db.cs
        ├── Forms/
        │   ├── FrmMain.cs
        │   ├── FrmChucVu.cs
        │   ├── FrmPhongBan.cs
        │   ├── FrmNhanVien.cs
        │   ├── FrmHoSoUngTuyen.cs
        │   └── FrmQuyetDinhTuyenDung.cs
        └── Services/
            ├── ChucVuService.cs
            ├── PhongBanService.cs
            ├── NhanVienService.cs
            ├── HoSoUngTuyenService.cs
            └── QuyetDinhTuyenDungService.cs
```

## Cách chạy

### 1. Chuẩn bị máy

Bạn cần Windows 10/11, Visual Studio 2022 (có workload **.NET desktop development**), SQL Server và SSMS. Dùng SQL Server LocalDB cũng được nếu không muốn cài bản đầy đủ.

Mình cài SQL Server 2025 như sau:

1. Chỉ chọn **Database Engine Services**.
2. Chọn **Named instance** và đặt tên `SQL2025`.
3. Chọn **Mixed Mode**, đặt mật khẩu cho `sa`, rồi bấm **Add Current User**.
4. Cài SSMS 22 và kết nối vào `.\SQL2025`, nhớ tick **Trust server certificate**.

### 2. Lấy code về

```bash
git clone <URL-repository-của-bạn>
cd LAB_OOSD/LAB7
```

### 3. Tạo database

1. Mở SSMS, kết nối vào `.\SQL2025`.
2. Mở file `QL_NhanSu.sql` (File → Open → File).
3. Đọc lướt qua xem script đã có lệnh `CREATE DATABASE` chưa. Nếu chưa, tự tạo database `QL_NhanSu` trước.
4. Bấm **Execute** (F5), rồi refresh **Databases** để kiểm tra các bảng và dữ liệu mẫu.

### 4. Sửa chuỗi kết nối

Chuỗi kết nối nằm trong `Data/db.cs` hoặc `App.config`. Xem code đang đọc từ chỗ nào rồi chỉ sửa đúng chỗ đó, đừng sửa cả hai.

Dùng Windows Authentication:

```csharp
@"Data Source=.\SQL2025;Initial Catalog=QL_NhanSu;Integrated Security=True;TrustServerCertificate=True;"
```

Dùng tài khoản `sa`:

```csharp
@"Data Source=.\SQL2025;Initial Catalog=QL_NhanSu;User ID=sa;Password=<mật-khẩu>;TrustServerCertificate=True;"
```

Dùng LocalDB:

```csharp
@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=QL_NhanSu;Integrated Security=True;TrustServerCertificate=True;"
```

Nếu dùng `App.config` thì khai báo như sau:

```xml
<connectionStrings>
    <add name="QL_NhanSu"
         connectionString="Data Source=.\SQL2025;Initial Catalog=QL_NhanSu;Integrated Security=True;TrustServerCertificate=True;"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

Hai điều cần nhớ: SQL Server bản mới mã hóa kết nối mặc định, nên trên máy cá nhân phải có `TrustServerCertificate=True`. Và đừng đẩy mật khẩu thật lên GitHub.

### 5. Build và chạy

1. Mở `LAB7.sln`, chọn project `QuanLyNhanSu` làm Startup Project.
2. **Build → Build Solution**, sửa lỗi nếu có.
3. Nhấn **F5**.

Chương trình mở bằng `FrmMain`, khai báo trong `Program.cs`:

```csharp
Application.Run(new FrmMain());
```

### Thử nhanh xem kết nối được chưa

```csharp
using (var conn = new SqlConnection(db.ConnectionString))
{
    conn.Open();
    MessageBox.Show("Kết nối thành công!");
}
```

## Gặp lỗi thì xem ở đây

| Lỗi | Cách xử lý |
|---|---|
| `The certificate chain was issued by an authority that is not trusted` | Thêm `TrustServerCertificate=True` vào chuỗi kết nối (hoặc tick Trust server certificate trong SSMS) |
| `A network-related or instance-specific error` | Kiểm tra tên instance `.\SQL2025` và xem dịch vụ `SQL Server (SQL2025)` đã chạy trong `services.msc` chưa |
| `Cannot open database "QL_NhanSu"` | Chưa tạo database, chạy `QL_NhanSu.sql` |
| `Login failed for user` | Sai tài khoản hoặc mật khẩu, hoặc server chưa bật Mixed Mode khi dùng `sa` |
| `CS0246: type or namespace could not be found` | Thiếu class model hoặc thiếu `using`, kiểm tra `Models.cs` đã nằm trong project |
| Mở lên chỉ thấy form trắng | `Program.cs` đang mở `Form1`, đổi thành `FrmMain` |

## Ghi chú thêm

- Cần tạo xong database `QL_NhanSu` trước khi chạy ứng dụng.
- Tài khoản đăng nhập mẫu (nếu có) nằm trong script SQL hoặc code, xem ở đó thay vì đoán.
- Các nghiệp vụ ghi vào nhiều bảng cùng lúc nên bọc trong transaction.

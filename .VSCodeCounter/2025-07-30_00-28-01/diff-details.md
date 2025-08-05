# Diff Details

Date : 2025-07-30 00:28:01

Directory c:\\Users\\kursa\\source\\repos\\MİniERP2_form_siifirdan

Total : 46 files,  -1246 codes, -65 comments, -249 blanks, all -1560 lines

[Summary](results.md) / [Details](details.md) / [Diff Summary](diff.md) / Diff Details

## Files
| filename | language | code | comment | blank | total |
| :--- | :--- | ---: | ---: | ---: | ---: |
| [MiniERP.API/Controllers/CollectionController.cs](/MiniERP.API/Controllers/CollectionController.cs) | C# | -163 | -36 | -38 | -237 |
| [MiniERP.API/Controllers/PaymentController.cs](/MiniERP.API/Controllers/PaymentController.cs) | C# | -176 | -39 | -41 | -256 |
| [MiniERP.API/Controllers/PaymentTypeController.cs](/MiniERP.API/Controllers/PaymentTypeController.cs) | C# | -209 | -26 | -30 | -265 |
| [MiniERP.API/Controllers/UserController.cs](/MiniERP.API/Controllers/UserController.cs) | C# | 24 | 2 | 2 | 28 |
| [MiniERP.API/DTOs/PaymentDto.cs](/MiniERP.API/DTOs/PaymentDto.cs) | C# | -124 | 0 | -11 | -135 |
| [MiniERP.API/Data/AppDbContext.cs](/MiniERP.API/Data/AppDbContext.cs) | C# | -28 | 0 | -7 | -35 |
| [MiniERP.API/Mappings/AutoMapperProfile.cs](/MiniERP.API/Mappings/AutoMapperProfile.cs) | C# | -17 | -3 | -2 | -22 |
| [MiniERP.API/Models/CariAccount.cs](/MiniERP.API/Models/CariAccount.cs) | C# | -2 | 0 | 0 | -2 |
| [MiniERP.API/Models/Collection.cs](/MiniERP.API/Models/Collection.cs) | C# | -33 | -1 | -12 | -46 |
| [MiniERP.API/Models/Payment.cs](/MiniERP.API/Models/Payment.cs) | C# | -33 | -1 | -12 | -46 |
| [MiniERP.API/Models/PaymentType.cs](/MiniERP.API/Models/PaymentType.cs) | C# | -24 | -1 | -8 | -33 |
| [MiniERP.API/Program.cs](/MiniERP.API/Program.cs) | C# | -4 | 0 | 0 | -4 |
| [MiniERP.API/Repositories/CariAccountRepository.cs](/MiniERP.API/Repositories/CariAccountRepository.cs) | C# | -2 | 0 | 0 | -2 |
| [MiniERP.API/Repositories/CollectionRepository.cs](/MiniERP.API/Repositories/CollectionRepository.cs) | C# | -112 | 0 | -17 | -129 |
| [MiniERP.API/Repositories/ICollectionRepository.cs](/MiniERP.API/Repositories/ICollectionRepository.cs) | C# | -17 | 0 | -1 | -18 |
| [MiniERP.API/Repositories/IPaymentRepository.cs](/MiniERP.API/Repositories/IPaymentRepository.cs) | C# | -17 | 0 | -1 | -18 |
| [MiniERP.API/Repositories/IUnitOfWork.cs](/MiniERP.API/Repositories/IUnitOfWork.cs) | C# | -3 | 0 | 0 | -3 |
| [MiniERP.API/Repositories/PaymentRepository.cs](/MiniERP.API/Repositories/PaymentRepository.cs) | C# | -112 | 0 | -17 | -129 |
| [MiniERP.API/Repositories/UnitOfWork.cs](/MiniERP.API/Repositories/UnitOfWork.cs) | C# | -6 | 0 | 0 | -6 |
| [MiniERP.API/Services/AuthService.cs](/MiniERP.API/Services/AuthService.cs) | C# | 13 | 4 | 3 | 20 |
| [MiniERP.API/Services/CollectionService.cs](/MiniERP.API/Services/CollectionService.cs) | C# | -309 | -13 | -52 | -374 |
| [MiniERP.API/Services/ICollectionService.cs](/MiniERP.API/Services/ICollectionService.cs) | C# | -19 | 0 | -1 | -20 |
| [MiniERP.API/Services/IPaymentService.cs](/MiniERP.API/Services/IPaymentService.cs) | C# | -20 | 0 | -1 | -21 |
| [MiniERP.API/Services/PaymentService.cs](/MiniERP.API/Services/PaymentService.cs) | C# | -337 | -13 | -57 | -407 |
| [MiniERP.Web/Controllers/ApiTestController.cs](/MiniERP.Web/Controllers/ApiTestController.cs) | C# | 215 | 8 | 22 | 245 |
| [MiniERP.Web/Controllers/AuthController.cs](/MiniERP.Web/Controllers/AuthController.cs) | C# | 0 | 1 | 0 | 1 |
| [MiniERP.Web/Controllers/UserController.cs](/MiniERP.Web/Controllers/UserController.cs) | C# | 53 | 3 | 3 | 59 |
| [MiniERP.Web/Models/PaymentModels.cs](/MiniERP.Web/Models/PaymentModels.cs) | C# | -156 | 0 | -37 | -193 |
| [MiniERP.Web/Program.cs](/MiniERP.Web/Program.cs) | C# | 12 | 4 | 5 | 21 |
| [MiniERP.Web/Services/ApiService.cs](/MiniERP.Web/Services/ApiService.cs) | C# | 210 | 11 | 6 | 227 |
| [MiniERP.Web/Services/AuthService.cs](/MiniERP.Web/Services/AuthService.cs) | C# | 9 | 0 | 2 | 11 |
| [MiniERP.Web/Services/FileLoggerProvider.cs](/MiniERP.Web/Services/FileLoggerProvider.cs) | C# | 59 | 1 | 13 | 73 |
| [MiniERP.Web/Services/PaymentService.cs](/MiniERP.Web/Services/PaymentService.cs) | C# | -287 | -3 | -38 | -328 |
| [MiniERP.Web/Services/ProductService.cs](/MiniERP.Web/Services/ProductService.cs) | C# | 19 | 0 | 4 | 23 |
| [MiniERP.Web/Views/ApiTest/Index.cshtml](/MiniERP.Web/Views/ApiTest/Index.cshtml) | ASP.NET Razor | 90 | 0 | 11 | 101 |
| [MiniERP.Web/Views/Shared/\_Layout.cshtml](/MiniERP.Web/Views/Shared/_Layout.cshtml) | ASP.NET Razor | -27 | 0 | 1 | -26 |
| [MiniERP.Web/Views/User/Index.cshtml](/MiniERP.Web/Views/User/Index.cshtml) | ASP.NET Razor | 5 | 0 | 1 | 6 |
| [MiniERP.WinForms/Forms/CariEkstreForm.cs](/MiniERP.WinForms/Forms/CariEkstreForm.cs) | C# | 56 | 10 | 11 | 77 |
| [MiniERP.WinForms/Forms/CariHareketleriForm.cs](/MiniERP.WinForms/Forms/CariHareketleriForm.cs) | C# | 79 | 13 | 15 | 107 |
| [MiniERP.WinForms/Forms/KullaniciYonetimiForm.cs](/MiniERP.WinForms/Forms/KullaniciYonetimiForm.cs) | C# | 71 | 11 | 11 | 93 |
| [MiniERP.WinForms/Forms/MainForm.Designer.cs](/MiniERP.WinForms/Forms/MainForm.Designer.cs) | C# | -48 | -9 | 0 | -57 |
| [MiniERP.WinForms/Forms/MainForm.cs](/MiniERP.WinForms/Forms/MainForm.cs) | C# | -12 | 0 | -3 | -15 |
| [MiniERP.WinForms/Forms/SatisFaturaDetayForm.cs](/MiniERP.WinForms/Forms/SatisFaturaDetayForm.cs) | C# | 28 | 6 | 15 | 49 |
| [MiniERP.WinForms/Helpers/DebugLogger.cs](/MiniERP.WinForms/Helpers/DebugLogger.cs) | C# | 42 | 2 | 9 | 53 |
| [MiniERP.WinForms/Program.cs](/MiniERP.WinForms/Program.cs) | C# | 0 | 0 | -1 | -1 |
| [MiniERP.WinForms/Services/ApiService.cs](/MiniERP.WinForms/Services/ApiService.cs) | C# | 66 | 4 | 4 | 74 |

[Summary](results.md) / [Details](details.md) / [Diff Summary](diff.md) / Diff Details
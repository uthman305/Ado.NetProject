using AdoProject.Data;
using AdoProject.Menu;

DBContext db = new DBContext();
// db.AgentTable();
// db.CustomerTable();
// db.UserTable();
// db.WalletTable();
// db.DepositTable();
// db.PurchaseTable();
// db.CompanyTable();
// db.CompanyDirectorTable();
MainMenu mainMenu = new MainMenu();
mainMenu.Main();
CustomerMenu customerMenu = new CustomerMenu();
customerMenu.DepositMenu();


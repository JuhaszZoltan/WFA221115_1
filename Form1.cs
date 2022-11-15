using System.Data.SqlClient;
using WFA221115_1.Properties;

namespace WFA221115_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using SqlConnection conn = new(
                connectionString:
                "Server=(localdb)\\MSSQLLocalDB;" +
                $"AttachDbFilename={Resources.DataBasePath};" +
                "Database=masiki_nev;" +
                "Trusted_Connection=Yes;");
            conn.Open();

            SqlDataReader reader = new SqlCommand(
                "SELECT emberek.id, nev, varos " +
                "FROM emberek " +
                "LEFT JOIN varosok " +
                "ON lakhelyId = varosok.id;",
                conn)
                .ExecuteReader();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(
                    reader.GetInt32(0),
                    reader[1],
                    reader["varos"]);
            }
        }
    }
}
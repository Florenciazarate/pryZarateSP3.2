using System;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using pryZarateSP3._2.Entidades;

namespace pryZarateSP3._2.Datos
{
    public class TodoPlastContext : DbContext
    {
        public TodoPlastContext() : base("name=TodoPlastContext")
        {
            Database.SetInitializer<TodoPlastContext>(null);
            EnsureDatabaseCreated();
        }

        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<OrdenProduccion> Ordenes { get; set; }

        private static void EnsureDatabaseCreated()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "todoplast.db");
            if (File.Exists(path)) return;

            SQLiteConnection.CreateFile(path);
            using (var conn = new SQLiteConnection("Data Source=" + path + ";Version=3;"))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE Maquinas (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nombre TEXT NOT NULL,
                            CapacidadInyeccion INTEGER NOT NULL
                        );
                        CREATE TABLE Ordenes (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Descripcion TEXT NOT NULL,
                            MaquinaId INTEGER NOT NULL,
                            HorasTrabajo INTEGER NOT NULL,
                            FOREIGN KEY (MaquinaId) REFERENCES Maquinas(Id)
                        );";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

using MeLembreiApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SQLite;

namespace MeLembreiApp.Persistencia
{
    public class LembreteDatabase 
    {
        readonly SQLiteAsyncConnection database;

        public LembreteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Lembrete>().Wait();
        }

        public Task<List<Lembrete>> ListarLembretesAsync(Expression<Func<Lembrete, bool>> pesquisa)
        {
            return database.Table<Lembrete>().Where(pesquisa).OrderBy(x => x.DataLimite).ToListAsync();
        }

        public Task<List<Lembrete>> TodosLembretesAsync()
        {
            return database.Table<Lembrete>().OrderBy(x => x.DataLimite).ToListAsync();
        }

        public Task<List<Lembrete>> LembretesPorDataAsync(DateTime date)
        {
            return database.QueryAsync<Lembrete>(string.Format("SELECT * FROM Lembrete WHERE date(DataLimite) BETWEEN date({0}) AND date({0})", date.ToString("yyyy/M/d")));
        }

        public Task<Lembrete> ObterPorIdAsync(int id)
        {
            return database.Table<Lembrete>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SalvarLembreteAsync(Lembrete lembrete)
        {
            if (lembrete.Id != 0)
            {
                return database.UpdateAsync(lembrete);
            }
            else
            {
                return database.InsertAsync(lembrete);
            }
        }

        public Task<int> DeletarLembreteAsync(Lembrete lembrete)
        {
            return database.DeleteAsync(lembrete);
        }
    }
}

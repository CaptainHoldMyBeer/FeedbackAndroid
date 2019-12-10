using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using feedback.Models;


namespace feedback.Data
{
    public class feedbackDataBase
    {
        readonly SQLiteAsyncConnection _database;

        public feedbackDataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Comment>().Wait();
        }

        public Task<List<Comment>> GetCommentAsync()
        {
            return _database.Table<Comment>().ToListAsync();
        }

        public Task<Comment> GetCommentAsync(int id)
        {
            return _database.Table<Comment>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCommentAsync(Comment comment)
        {
            if (comment.ID != 0)
            {
                return _database.UpdateAsync(comment);
            }
            else
            {
                return _database.InsertAsync(comment);
            }
        }

        public Task<int> DeleteNoteAsync(Comment comment)
        {
            return _database.DeleteAsync(comment);
        }
    }
}

using MobileLabProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileLabProject
{
    public class WordsRepository
    {
        SQLiteConnection database;
        public WordsRepository(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Word>();
        }

        public IEnumerable<Word> GetWords()
        {
            return database.Table<Word>().ToList();
        }
        public Word GetWord(int id)
        {
            return database.Get<Word>(id);
        }

        public int DeleteWord(int id)
        {
            return database.Delete<Word>(id);
        }
        public int SaveWord(Word word)
        {
            if (word.Id != 0)
            {
                database.Update(word);
                return word.Id;
            }
            return database.Insert(word);
        }
    }
}

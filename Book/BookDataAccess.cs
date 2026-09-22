using System;
using System.Collections.Generic;
using System.IO;

namespace Book
{
    public class BookDataAccess
    {
        private readonly string fileName = "books.txt";
        private readonly string backupfileName = "books_backup.txt";
        public void AddBook(Book book)
        {
            FileStream fin = new FileStream(fileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(fin);
            string record = $"{book.Id},{book.Title},{book.Author},{book.Price}";
            writer.WriteLine(record);
            writer.Close();
            fin.Close();
        }

        public List<Book> ViewAllBooks()
        { 
            List<Book> list = new List<Book>();
            if (!File.Exists(fileName))
            {
                return list;
            }
            FileStream fout = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fout);
            string? line = reader.ReadLine();

            while (line != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    Book book = new Book();
                    book.Id = int.Parse(parts[0]);
                    book.Title = parts[1];
                    book.Author = parts[2];
                    book.Price = double.Parse(parts[3]);

                    list.Add(book);
                }

                line = reader.ReadLine();
            }

            reader.Close();
            fout.Close();
            return list;
        }

        public Book FindBookById(int id)
        {
            List<Book> books = ViewAllBooks();
            Dictionary<int, Book> dict = new Dictionary<int, Book>();
            foreach (Book b in books)
            {
                dict[b.Id] = b;
            }
            if(dict.TryGetValue(id,out Book? foundBook))
            {
                return foundBook;
            }
            return null;
        }

        public void CreateBackup()
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("No source file found to backup.");
                return;
            }
            FileStream source = new FileStream(fileName,FileMode.Open);
            FileStream destination = new FileStream(backupfileName, FileMode.Create);
            int readByte = source.ReadByte();

            while (readByte != -1)
            {
                destination.WriteByte((byte)readByte);

                readByte = source.ReadByte();
            }

            source.Close();
            destination.Close();
        }
    }
}
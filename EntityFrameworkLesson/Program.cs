using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLesson
{
    //для миграции ДБ в консоль прописать enable-migrations(1 раз)  затем  add-migration AddGroupType(при изменении для синхронизации) и в конце update-database(непосредственно обновление)
    class Program
    {
        static void Main(string[] args)
        {
            using(var context=new MyDBContext())
            {
                // TODO: при перезапуске строки будут добавляться. Добавить очищение БД перед запуском.
                //создаем новые строки в БД групп
                var group = new Group()
                {
                    Name = "Rammstein",
                    Year = 1994
                };
                var group2 = new Group()
                {
                    Name = "Linkin park",
                    Year = 1996
                };
                //добавляем их в "промежуточное,локальное" хранилище
                context.Groups.Add(group);
                context.Groups.Add(group2);
                //добавляем изменения в БД
                context.SaveChanges();

                //создаем новые строки для песен
                var songs = new List<Song>()
                {
                    new Song(){Name="In the end",GroupId=group2.Id},
                    new Song(){Name="Numb",GroupId=group2.Id},
                    new Song(){Name="Mutter",GroupId=group.Id}
                };
                context.Songs.AddRange(songs);
                context.SaveChanges();


                #region обновление через Linq. Пример:
                var s = context.Groups.Single(x => x.Id == group.Id);
                s.Name = "New name";
                context.SaveChanges();
                #endregion


                foreach (var item in songs)
                {
                    Console.WriteLine($"ID:{item.Id}, name: {item.Name}, group: {item.Group?.Name}.");
                }

                Console.ReadKey();

            }
        }
    }
}

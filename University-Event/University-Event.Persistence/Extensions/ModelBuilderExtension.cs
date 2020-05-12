using System;
using Microsoft.EntityFrameworkCore;
using University_Event.Domain;

namespace University_Event.Persistence.Extensions
{
    public static class ModelBuilderExtension
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedAdmin(modelBuilder);
            SeedEvent(modelBuilder);
            SeedStudent(modelBuilder);
            SeedEventStudent(modelBuilder);
        }
        public static void SeedStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    ID = "123456c",
                    LastName = "Громов",
                    FirstName = "Вадим",
                    MiddleName = "Глібович",
                    Password = "123456c"
                }
            );
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    ID = "123457c",
                    LastName = "Тимець",
                    FirstName = "Данило",
                    MiddleName = "Ігорович",
                    Password = "123457c"
                }
            );
        }
        public static void SeedAdmin(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Email = "admin@gmail.com",
                    Password = "admin"
                }
            );
        }
        public static void SeedEvent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    ShortTitle = "Шаховий турнір.",
                    LongTitle = "Профспілка студентів орзанізовує шаховий турнір між студентами. Запрошуємо усіх бажаючих.",
                    NumberOfPeople = 24,
                    Date = new DateTime(2020, 06, 29)
                }
            ); 
        }
        public static void SeedEventStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventStudent>().HasData(
                new EventStudent
                {
                    Id = 1,
                    EventId = 1,
                    StudentId = "123456c"
                }
            );
            modelBuilder.Entity<EventStudent>().HasData(
                new EventStudent
                {
                    Id = 2,
                    EventId = 1,
                    StudentId = "123457c"
                }
            );
        }
    }
}

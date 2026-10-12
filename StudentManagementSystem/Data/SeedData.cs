using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext db)
        {
            if (db.Students.Any()) return;

            db.Students.AddRange(
                new Student { FullName = "Aarav Patel", Email = "aarav@example.com", Phone = "9876543210", Course = "IMCA", Semester = 3, EnrollmentDate = new DateTime(2024, 7, 1) },
                new Student { FullName = "Diya Shah", Email = "diya@example.com", Phone = "9876501234", Course = "BCA", Semester = 5, EnrollmentDate = new DateTime(2023, 7, 1) },
                new Student { FullName = "Rohan Mehta", Email = "rohan@example.com", Phone = "9123456780", Course = "MCA", Semester = 1, EnrollmentDate = new DateTime(2025, 7, 1) }
            );
            db.SaveChanges();
        }
    }
}

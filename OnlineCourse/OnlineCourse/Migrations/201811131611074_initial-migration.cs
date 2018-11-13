namespace OnlineCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentVsCourse", "StudentRefId", "dbo.Student");
            DropForeignKey("dbo.StudentVsCourse", "CourseRefId", "dbo.Course");
            DropIndex("dbo.StudentVsCourse", new[] { "StudentRefId" });
            DropIndex("dbo.StudentVsCourse", new[] { "CourseRefId" });
            CreateIndex("dbo.Student", "CurrentCourseId");
            AddForeignKey("dbo.Student", "CurrentCourseId", "dbo.Course", "Id", cascadeDelete: true);
            DropTable("dbo.StudentVsCourse");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentVsCourse",
                c => new
                    {
                        StudentRefId = c.Int(nullable: false),
                        CourseRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentRefId, t.CourseRefId });
            
            DropForeignKey("dbo.Student", "CurrentCourseId", "dbo.Course");
            DropIndex("dbo.Student", new[] { "CurrentCourseId" });
            CreateIndex("dbo.StudentVsCourse", "CourseRefId");
            CreateIndex("dbo.StudentVsCourse", "StudentRefId");
            AddForeignKey("dbo.StudentVsCourse", "CourseRefId", "dbo.Course", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentVsCourse", "StudentRefId", "dbo.Student", "Id", cascadeDelete: true);
        }
    }
}

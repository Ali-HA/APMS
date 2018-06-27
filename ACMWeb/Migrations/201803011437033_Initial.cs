namespace ACMWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssessmentGrades",
                c => new
                    {
                        AssessmentGradeID = c.Int(nullable: false, identity: true),
                        Grade = c.Double(),
                        Grade4 = c.Double(),
                        GradeP = c.Double(),
                        GradeS = c.Double(),
                        GradeItemID = c.Int(nullable: false),
                        EnrollID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssessmentGradeID)
                .ForeignKey("dbo.GradeItems", t => t.GradeItemID, cascadeDelete: true)
                .ForeignKey("dbo.Enrolls", t => t.EnrollID, cascadeDelete: true)
                .Index(t => new { t.GradeItemID, t.EnrollID }, unique: true, name: "IX_Grade_Enroll");
            
            CreateTable(
                "dbo.Enrolls",
                c => new
                    {
                        SectionID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        LetterGradeID = c.Int(),
                        EnrollID = c.Int(nullable: false, identity: true),
                        EnrollmentDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollID)
                .ForeignKey("dbo.LetterGrades", t => t.LetterGradeID)
                .ForeignKey("dbo.Sections", t => t.SectionID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => new { t.SectionID, t.StudentID }, unique: true, name: "IX_Enrol_Student_Section")
                .Index(t => t.LetterGradeID);
            
            CreateTable(
                "dbo.LetterGrades",
                c => new
                    {
                        LetterGradeID = c.Int(nullable: false, identity: true),
                        Grade = c.String(),
                        MinGrade = c.Double(nullable: false),
                        MaxGrade = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LetterGradeID);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionID = c.Int(nullable: false),
                        Code = c.String(maxLength: 50),
                        CourseID = c.Int(nullable: false),
                        SemesterID = c.Int(nullable: false),
                        Room = c.String(),
                        ClassInstructorID = c.Int(),
                        LabInstructorID = c.Int(),
                        GradeDistributionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SectionID)
                .ForeignKey("dbo.Instructors", t => t.ClassInstructorID)
                .ForeignKey("dbo.GradeDistributions", t => t.GradeDistributionID, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.LabInstructorID)
                .Index(t => t.CourseID)
                .Index(t => t.SemesterID)
                .Index(t => t.ClassInstructorID)
                .Index(t => t.LabInstructorID)
                .Index(t => t.GradeDistributionID);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DepartmentID = c.Int(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InstructorID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        FullName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Credits = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.PIMappings",
                c => new
                    {
                        PIMappingID = c.Int(nullable: false, identity: true),
                        SemesterID = c.Int(nullable: false),
                        PIID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        GradeItemID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PIMappingID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.GradeItems", t => t.GradeItemID, cascadeDelete: true)
                .ForeignKey("dbo.PIs", t => t.PIID, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterID, cascadeDelete: true)
                .Index(t => new { t.SemesterID, t.PIID, t.CourseID, t.GradeItemID }, unique: true, name: "IX_PI_Mapping");
            
            CreateTable(
                "dbo.GradeItems",
                c => new
                    {
                        GradeItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AssessmentTypeID = c.Int(nullable: false),
                        AssessmentTNo = c.Int(nullable: false),
                        CrNo = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        GradeDistributionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GradeItemID)
                .ForeignKey("dbo.AssessmentTypes", t => t.AssessmentTypeID, cascadeDelete: true)
                .ForeignKey("dbo.GradeDistributions", t => t.GradeDistributionID)
                .Index(t => t.AssessmentTypeID)
                .Index(t => t.GradeDistributionID);
            
            CreateTable(
                "dbo.AssessmentTypes",
                c => new
                    {
                        AssessmentTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.AssessmentTypeID);
            
            CreateTable(
                "dbo.GradeDistributions",
                c => new
                    {
                        GradeDistributionID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EffectiveDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GradeDistributionID);
            
            CreateTable(
                "dbo.PIs",
                c => new
                    {
                        PIID = c.Int(nullable: false, identity: true),
                        LOID = c.Int(nullable: false),
                        PILetter = c.String(),
                        PINo = c.Int(nullable: false),
                        PIDesc = c.String(),
                    })
                .PrimaryKey(t => t.PIID)
                .ForeignKey("dbo.LOes", t => t.LOID, cascadeDelete: true)
                .Index(t => t.LOID);
            
            CreateTable(
                "dbo.LOes",
                c => new
                    {
                        LOID = c.Int(nullable: false, identity: true),
                        LearningOutcome = c.String(),
                        LODesc = c.String(),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LOID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                        ShortName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SemesterID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DepartmentID = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssessmentGrades", "EnrollID", "dbo.Enrolls");
            DropForeignKey("dbo.Enrolls", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Enrolls", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.Sections", "LabInstructorID", "dbo.Instructors");
            DropForeignKey("dbo.Students", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Instructors", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Sections", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.PIMappings", "SemesterID", "dbo.Semesters");
            DropForeignKey("dbo.Sections", "SemesterID", "dbo.Semesters");
            DropForeignKey("dbo.PIMappings", "PIID", "dbo.PIs");
            DropForeignKey("dbo.PIs", "LOID", "dbo.LOes");
            DropForeignKey("dbo.LOes", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.PIMappings", "GradeItemID", "dbo.GradeItems");
            DropForeignKey("dbo.GradeItems", "GradeDistributionID", "dbo.GradeDistributions");
            DropForeignKey("dbo.Sections", "GradeDistributionID", "dbo.GradeDistributions");
            DropForeignKey("dbo.GradeItems", "AssessmentTypeID", "dbo.AssessmentTypes");
            DropForeignKey("dbo.AssessmentGrades", "GradeItemID", "dbo.GradeItems");
            DropForeignKey("dbo.PIMappings", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Sections", "ClassInstructorID", "dbo.Instructors");
            DropForeignKey("dbo.Enrolls", "LetterGradeID", "dbo.LetterGrades");
            DropIndex("dbo.Students", new[] { "DepartmentID" });
            DropIndex("dbo.LOes", new[] { "DepartmentID" });
            DropIndex("dbo.PIs", new[] { "LOID" });
            DropIndex("dbo.GradeItems", new[] { "GradeDistributionID" });
            DropIndex("dbo.GradeItems", new[] { "AssessmentTypeID" });
            DropIndex("dbo.PIMappings", "IX_PI_Mapping");
            DropIndex("dbo.Courses", new[] { "DepartmentID" });
            DropIndex("dbo.Instructors", new[] { "DepartmentID" });
            DropIndex("dbo.Sections", new[] { "GradeDistributionID" });
            DropIndex("dbo.Sections", new[] { "LabInstructorID" });
            DropIndex("dbo.Sections", new[] { "ClassInstructorID" });
            DropIndex("dbo.Sections", new[] { "SemesterID" });
            DropIndex("dbo.Sections", new[] { "CourseID" });
            DropIndex("dbo.Enrolls", new[] { "LetterGradeID" });
            DropIndex("dbo.Enrolls", "IX_Enrol_Student_Section");
            DropIndex("dbo.AssessmentGrades", "IX_Grade_Enroll");
            DropTable("dbo.Students");
            DropTable("dbo.Semesters");
            DropTable("dbo.LOes");
            DropTable("dbo.PIs");
            DropTable("dbo.GradeDistributions");
            DropTable("dbo.AssessmentTypes");
            DropTable("dbo.GradeItems");
            DropTable("dbo.PIMappings");
            DropTable("dbo.Courses");
            DropTable("dbo.Departments");
            DropTable("dbo.Instructors");
            DropTable("dbo.Sections");
            DropTable("dbo.LetterGrades");
            DropTable("dbo.Enrolls");
            DropTable("dbo.AssessmentGrades");
        }
    }
}

namespace MyBusinessAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        AttendenceId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsPresent = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy_PersonId = c.Int(),
                        Student_StudentId = c.Int(),
                        SubjectTeacherStandardRelation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.AttendenceId)
                .ForeignKey("dbo.Person", t => t.CreatedBy_PersonId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .ForeignKey("dbo.SubjectTeacherStandardRelations", t => t.SubjectTeacherStandardRelation_Id)
                .Index(t => t.CreatedBy_PersonId)
                .Index(t => t.Student_StudentId)
                .Index(t => t.SubjectTeacherStandardRelation_Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        HomeAddress = c.String(),
                        OfficeAddress = c.String(),
                        ContactNumber2 = c.Int(nullable: false),
                        ContactNumber3 = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.IdentityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Standard_StandardId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Standards", t => t.Standard_StandardId)
                .Index(t => t.Standard_StandardId);
            
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        StandardId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StandardId);
            
            CreateTable(
                "dbo.SubjectTeacherStandardRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Standard_StandardId = c.Int(),
                        Subject_SubjectId = c.Int(),
                        Teacher_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Standards", t => t.Standard_StandardId)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId)
                .ForeignKey("dbo.Person", t => t.Teacher_PersonId)
                .Index(t => t.Standard_StandardId)
                .Index(t => t.Subject_SubjectId)
                .Index(t => t.Teacher_PersonId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.CommunicationMessages",
                c => new
                    {
                        CommunicationMessageId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        Updatedon = c.DateTime(nullable: false),
                        Createdby_PersonId = c.Int(),
                        Notification_EventNotificationId = c.Int(),
                        ParentMessage_CommunicationMessageId = c.Int(),
                    })
                .PrimaryKey(t => t.CommunicationMessageId)
                .ForeignKey("dbo.Person", t => t.Createdby_PersonId)
                .ForeignKey("dbo.EventNotifications", t => t.Notification_EventNotificationId)
                .ForeignKey("dbo.CommunicationMessages", t => t.ParentMessage_CommunicationMessageId)
                .Index(t => t.Createdby_PersonId)
                .Index(t => t.Notification_EventNotificationId)
                .Index(t => t.ParentMessage_CommunicationMessageId);
            
            CreateTable(
                "dbo.EventNotifications",
                c => new
                    {
                        EventNotificationId = c.Int(nullable: false, identity: true),
                        IsNotified = c.Boolean(nullable: false),
                        ScheduledOn = c.DateTime(nullable: false),
                        SchoolEvent_SchoolEventId = c.Int(),
                        TaggedPerson_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.EventNotificationId)
                .ForeignKey("dbo.SchoolEvents", t => t.SchoolEvent_SchoolEventId)
                .ForeignKey("dbo.Person", t => t.TaggedPerson_PersonId)
                .Index(t => t.SchoolEvent_SchoolEventId)
                .Index(t => t.TaggedPerson_PersonId);
            
            CreateTable(
                "dbo.SchoolEvents",
                c => new
                    {
                        SchoolEventId = c.Int(nullable: false, identity: true),
                        EventType = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        ScheduledOn = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        CreatedBy_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.SchoolEventId)
                .ForeignKey("dbo.Person", t => t.CreatedBy_PersonId)
                .Index(t => t.CreatedBy_PersonId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ScheduledOn = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        Createdby_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.ExamId)
                .ForeignKey("dbo.Person", t => t.Createdby_PersonId)
                .Index(t => t.Createdby_PersonId);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        descrioption = c.String(),
                        DurationFrom = c.DateTime(nullable: false),
                        DurationTo = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.StudentExams",
                c => new
                    {
                        StudentExamId = c.Int(nullable: false, identity: true),
                        IsPresent = c.Boolean(nullable: false),
                        AttendedOn = c.DateTime(nullable: false),
                        MarksObtained = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        CreatedBy_PersonId = c.Int(),
                        Student_StudentId = c.Int(),
                        SubjectExam_SubjectExamId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentExamId)
                .ForeignKey("dbo.Person", t => t.CreatedBy_PersonId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .ForeignKey("dbo.SubjectExams", t => t.SubjectExam_SubjectExamId)
                .Index(t => t.CreatedBy_PersonId)
                .Index(t => t.Student_StudentId)
                .Index(t => t.SubjectExam_SubjectExamId);
            
            CreateTable(
                "dbo.SubjectExams",
                c => new
                    {
                        SubjectExamId = c.Int(nullable: false, identity: true),
                        SceduledFrom = c.DateTime(nullable: false),
                        ScheduledTo = c.DateTime(nullable: false),
                        MaxMarks = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        CreatedBy_PersonId = c.Int(),
                        Exam_ExamId = c.Int(),
                        Subject_SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectExamId)
                .ForeignKey("dbo.Person", t => t.CreatedBy_PersonId)
                .ForeignKey("dbo.Exams", t => t.Exam_ExamId)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId)
                .Index(t => t.CreatedBy_PersonId)
                .Index(t => t.Exam_ExamId)
                .Index(t => t.Subject_SubjectId);
            
            CreateTable(
                "dbo.StudentParentRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Parent_PersonId = c.Int(),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Parent_PersonId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.Parent_PersonId)
                .Index(t => t.Student_StudentId);
            
            CreateTable(
                "dbo.SubjectPeriods",
                c => new
                    {
                        SubjectPeriodId = c.Int(nullable: false, identity: true),
                        SchecduledFrom = c.DateTime(nullable: false),
                        SchecduledTo = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        CreatedBy_PersonId = c.Int(),
                        SubjectTeacherStandardRelation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectPeriodId)
                .ForeignKey("dbo.Person", t => t.CreatedBy_PersonId)
                .ForeignKey("dbo.SubjectTeacherStandardRelations", t => t.SubjectTeacherStandardRelation_Id)
                .Index(t => t.CreatedBy_PersonId)
                .Index(t => t.SubjectTeacherStandardRelation_Id);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        SubscriptionId = c.Int(nullable: false, identity: true),
                        PlanId = c.Int(nullable: false),
                        SubscribedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Amount = c.Int(nullable: false),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.SubscriptionId)
                .ForeignKey("dbo.Plans", t => t.PlanId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.PlanId)
                .Index(t => t.Student_StudentId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Subscriptions", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Subscriptions", "PlanId", "dbo.Plans");
            DropForeignKey("dbo.SubjectPeriods", "SubjectTeacherStandardRelation_Id", "dbo.SubjectTeacherStandardRelations");
            DropForeignKey("dbo.SubjectPeriods", "CreatedBy_PersonId", "dbo.Person");
            DropForeignKey("dbo.StudentParentRelations", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentParentRelations", "Parent_PersonId", "dbo.Person");
            DropForeignKey("dbo.StudentExams", "SubjectExam_SubjectExamId", "dbo.SubjectExams");
            DropForeignKey("dbo.SubjectExams", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectExams", "Exam_ExamId", "dbo.Exams");
            DropForeignKey("dbo.SubjectExams", "CreatedBy_PersonId", "dbo.Person");
            DropForeignKey("dbo.StudentExams", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentExams", "CreatedBy_PersonId", "dbo.Person");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Exams", "Createdby_PersonId", "dbo.Person");
            DropForeignKey("dbo.CommunicationMessages", "ParentMessage_CommunicationMessageId", "dbo.CommunicationMessages");
            DropForeignKey("dbo.CommunicationMessages", "Notification_EventNotificationId", "dbo.EventNotifications");
            DropForeignKey("dbo.EventNotifications", "TaggedPerson_PersonId", "dbo.Person");
            DropForeignKey("dbo.EventNotifications", "SchoolEvent_SchoolEventId", "dbo.SchoolEvents");
            DropForeignKey("dbo.SchoolEvents", "CreatedBy_PersonId", "dbo.Person");
            DropForeignKey("dbo.CommunicationMessages", "Createdby_PersonId", "dbo.Person");
            DropForeignKey("dbo.Attendences", "SubjectTeacherStandardRelation_Id", "dbo.SubjectTeacherStandardRelations");
            DropForeignKey("dbo.SubjectTeacherStandardRelations", "Teacher_PersonId", "dbo.Person");
            DropForeignKey("dbo.SubjectTeacherStandardRelations", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectTeacherStandardRelations", "Standard_StandardId", "dbo.Standards");
            DropForeignKey("dbo.Attendences", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "Standard_StandardId", "dbo.Standards");
            DropForeignKey("dbo.Attendences", "CreatedBy_PersonId", "dbo.Person");
            DropForeignKey("dbo.Person", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.IdentityUsers");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.Subscriptions", new[] { "Student_StudentId" });
            DropIndex("dbo.Subscriptions", new[] { "PlanId" });
            DropIndex("dbo.SubjectPeriods", new[] { "SubjectTeacherStandardRelation_Id" });
            DropIndex("dbo.SubjectPeriods", new[] { "CreatedBy_PersonId" });
            DropIndex("dbo.StudentParentRelations", new[] { "Student_StudentId" });
            DropIndex("dbo.StudentParentRelations", new[] { "Parent_PersonId" });
            DropIndex("dbo.SubjectExams", new[] { "Subject_SubjectId" });
            DropIndex("dbo.SubjectExams", new[] { "Exam_ExamId" });
            DropIndex("dbo.SubjectExams", new[] { "CreatedBy_PersonId" });
            DropIndex("dbo.StudentExams", new[] { "SubjectExam_SubjectExamId" });
            DropIndex("dbo.StudentExams", new[] { "Student_StudentId" });
            DropIndex("dbo.StudentExams", new[] { "CreatedBy_PersonId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Exams", new[] { "Createdby_PersonId" });
            DropIndex("dbo.SchoolEvents", new[] { "CreatedBy_PersonId" });
            DropIndex("dbo.EventNotifications", new[] { "TaggedPerson_PersonId" });
            DropIndex("dbo.EventNotifications", new[] { "SchoolEvent_SchoolEventId" });
            DropIndex("dbo.CommunicationMessages", new[] { "ParentMessage_CommunicationMessageId" });
            DropIndex("dbo.CommunicationMessages", new[] { "Notification_EventNotificationId" });
            DropIndex("dbo.CommunicationMessages", new[] { "Createdby_PersonId" });
            DropIndex("dbo.SubjectTeacherStandardRelations", new[] { "Teacher_PersonId" });
            DropIndex("dbo.SubjectTeacherStandardRelations", new[] { "Subject_SubjectId" });
            DropIndex("dbo.SubjectTeacherStandardRelations", new[] { "Standard_StandardId" });
            DropIndex("dbo.Students", new[] { "Standard_StandardId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUsers", "UserNameIndex");
            DropIndex("dbo.Person", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Attendences", new[] { "SubjectTeacherStandardRelation_Id" });
            DropIndex("dbo.Attendences", new[] { "Student_StudentId" });
            DropIndex("dbo.Attendences", new[] { "CreatedBy_PersonId" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.SubjectPeriods");
            DropTable("dbo.StudentParentRelations");
            DropTable("dbo.SubjectExams");
            DropTable("dbo.StudentExams");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Plans");
            DropTable("dbo.Exams");
            DropTable("dbo.SchoolEvents");
            DropTable("dbo.EventNotifications");
            DropTable("dbo.CommunicationMessages");
            DropTable("dbo.Subjects");
            DropTable("dbo.SubjectTeacherStandardRelations");
            DropTable("dbo.Standards");
            DropTable("dbo.Students");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.IdentityUsers");
            DropTable("dbo.Person");
            DropTable("dbo.Attendences");
        }
    }
}

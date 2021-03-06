﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Isaac.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_9FE202_IsaacDevEntities : DbContext
    {
        public DB_9FE202_IsaacDevEntities()
            : base("name=DB_9FE202_IsaacDevEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserUseTemplate> UserUseTemplates { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<questionType> questionTypes { get; set; }
        public virtual DbSet<SubjectQuestion> SubjectQuestions { get; set; }
        public virtual DbSet<subjectTemplateQuestion> subjectTemplateQuestions { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<TemplateQuestion> TemplateQuestions { get; set; }
        public virtual DbSet<vw_TemplateQuestion> vw_TemplateQuestion { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<PersonalTemplate> PersonalTemplates { get; set; }
        public virtual DbSet<SubjectQuestion1> SubjectQuestion1 { get; set; }
        public virtual DbSet<TemplateQuestion1> TemplateQuestions1 { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<vw_TemplateQuestionOrder> vw_TemplateQuestionOrder { get; set; }
        public virtual DbSet<vw_TemplateSubjectQuestionOrder> vw_TemplateSubjectQuestionOrder { get; set; }
        public virtual DbSet<UserTitle> UserTitles { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
    
        public virtual int sp_addQuestiontoSubject(Nullable<int> templateID, Nullable<int> subjectID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            var subjectIDParameter = subjectID.HasValue ?
                new ObjectParameter("subjectID", subjectID) :
                new ObjectParameter("subjectID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_addQuestiontoSubject", templateIDParameter, subjectIDParameter);
        }
    
        public virtual int sp_addQuestiontoSubject2(Nullable<int> templateID, Nullable<int> subjectID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            var subjectIDParameter = subjectID.HasValue ?
                new ObjectParameter("subjectID", subjectID) :
                new ObjectParameter("subjectID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_addQuestiontoSubject2", templateIDParameter, subjectIDParameter);
        }
    
        public virtual int sp_addQuestiontoTemplate(Nullable<int> templateID, Nullable<int> questionID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("TemplateID", templateID) :
                new ObjectParameter("TemplateID", typeof(int));
    
            var questionIDParameter = questionID.HasValue ?
                new ObjectParameter("QuestionID", questionID) :
                new ObjectParameter("QuestionID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_addQuestiontoTemplate", templateIDParameter, questionIDParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_deleteSubejctByTemplate(Nullable<int> templateID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_deleteSubejctByTemplate", templateIDParameter);
        }
    
        public virtual int sp_deleteSubejctByTemplate2(Nullable<int> templateID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_deleteSubejctByTemplate2", templateIDParameter);
        }
    
        public virtual int sp_DeleteTemplateQuestionByQue(Nullable<int> templateID, Nullable<int> questionID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            var questionIDParameter = questionID.HasValue ?
                new ObjectParameter("questionID", questionID) :
                new ObjectParameter("questionID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteTemplateQuestionByQue", templateIDParameter, questionIDParameter);
        }
    
        public virtual int sp_DeleteTemplateQuestionByTemp(Nullable<int> templateID, Nullable<int> questionID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            var questionIDParameter = questionID.HasValue ?
                new ObjectParameter("questionID", questionID) :
                new ObjectParameter("questionID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteTemplateQuestionByTemp", templateIDParameter, questionIDParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<SP_FindUserIDnMembershipByName_Result> SP_FindUserIDnMembershipByName(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_FindUserIDnMembershipByName_Result>("SP_FindUserIDnMembershipByName", nameParameter);
        }
    
        public virtual int Sp_GeneralUserInsert(string userID, string roleID)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(string));
    
            var roleIDParameter = roleID != null ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_GeneralUserInsert", userIDParameter, roleIDParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_idFindTitle(string title)
        {
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_idFindTitle", titleParameter);
        }
    
        public virtual int sp_InsertOrderQuestionIDbyTemplateID(Nullable<int> templateID, Nullable<int> questionID, Nullable<int> questionOrder)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("TemplateID", templateID) :
                new ObjectParameter("TemplateID", typeof(int));
    
            var questionIDParameter = questionID.HasValue ?
                new ObjectParameter("QuestionID", questionID) :
                new ObjectParameter("QuestionID", typeof(int));
    
            var questionOrderParameter = questionOrder.HasValue ?
                new ObjectParameter("QuestionOrder", questionOrder) :
                new ObjectParameter("QuestionOrder", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertOrderQuestionIDbyTemplateID", templateIDParameter, questionIDParameter, questionOrderParameter);
        }
    
        public virtual int sp_insertSubjectQuestionbyTemplatebySubjectOrder(Nullable<int> templateID, Nullable<int> subejctID, Nullable<int> subjectOrder)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("TemplateID", templateID) :
                new ObjectParameter("TemplateID", typeof(int));
    
            var subejctIDParameter = subejctID.HasValue ?
                new ObjectParameter("SubejctID", subejctID) :
                new ObjectParameter("SubejctID", typeof(int));
    
            var subjectOrderParameter = subjectOrder.HasValue ?
                new ObjectParameter("SubjectOrder", subjectOrder) :
                new ObjectParameter("SubjectOrder", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_insertSubjectQuestionbyTemplatebySubjectOrder", templateIDParameter, subejctIDParameter, subjectOrderParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SP_lookTempIDbyTitle(string title)
        {
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SP_lookTempIDbyTitle", titleParameter);
        }
    
        public virtual ObjectResult<SP_QuestionByTemplateAndType_Result> SP_QuestionByTemplateAndType(Nullable<int> templateID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("TemplateID", templateID) :
                new ObjectParameter("TemplateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_QuestionByTemplateAndType_Result>("SP_QuestionByTemplateAndType", templateIDParameter);
        }
    
        public virtual ObjectResult<SP_QuestionContentByTemplate_Result> SP_QuestionContentByTemplate(Nullable<int> templateID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("TemplateID", templateID) :
                new ObjectParameter("TemplateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_QuestionContentByTemplate_Result>("SP_QuestionContentByTemplate", templateIDParameter);
        }
    
        public virtual ObjectResult<string> sp_questionIDbyContent(string questionContent)
        {
            var questionContentParameter = questionContent != null ?
                new ObjectParameter("QuestionContent", questionContent) :
                new ObjectParameter("QuestionContent", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_questionIDbyContent", questionContentParameter);
        }
    
        public virtual ObjectResult<sp_QuestionIDbyContentDistinct_Result> sp_QuestionIDbyContentDistinct(string questionContent)
        {
            var questionContentParameter = questionContent != null ?
                new ObjectParameter("QuestionContent", questionContent) :
                new ObjectParameter("QuestionContent", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_QuestionIDbyContentDistinct_Result>("sp_QuestionIDbyContentDistinct", questionContentParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_QuestionTemplate(Nullable<int> templateID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_QuestionTemplate", templateIDParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual ObjectResult<string> sp_SubjectQuestionContentbyTemplateID(Nullable<int> templateID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_SubjectQuestionContentbyTemplateID", templateIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_SubjectQuestionIDbyTemplateID(Nullable<int> templateID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_SubjectQuestionIDbyTemplateID", templateIDParameter);
        }
    
        public virtual int sp_UpdateTemplateQuestions(Nullable<int> templateID, Nullable<int> questionID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            var questionIDParameter = questionID.HasValue ?
                new ObjectParameter("questionID", questionID) :
                new ObjectParameter("questionID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateTemplateQuestions", templateIDParameter, questionIDParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<TemplateByCategory_Result> TemplateByCategory(Nullable<int> category)
        {
            var categoryParameter = category.HasValue ?
                new ObjectParameter("Category", category) :
                new ObjectParameter("Category", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TemplateByCategory_Result>("TemplateByCategory", categoryParameter);
        }
    
        public virtual int sp_updateTempate(string context, string title, Nullable<int> modifiedTime, Nullable<int> categoryID, string subject, Nullable<int> iD)
        {
            var contextParameter = context != null ?
                new ObjectParameter("Context", context) :
                new ObjectParameter("Context", typeof(string));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var modifiedTimeParameter = modifiedTime.HasValue ?
                new ObjectParameter("ModifiedTime", modifiedTime) :
                new ObjectParameter("ModifiedTime", typeof(int));
    
            var categoryIDParameter = categoryID.HasValue ?
                new ObjectParameter("CategoryID", categoryID) :
                new ObjectParameter("CategoryID", typeof(int));
    
            var subjectParameter = subject != null ?
                new ObjectParameter("Subject", subject) :
                new ObjectParameter("Subject", typeof(string));
    
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_updateTempate", contextParameter, titleParameter, modifiedTimeParameter, categoryIDParameter, subjectParameter, iDParameter);
        }
    
        public virtual int sp_QuestionBindingAndCreateDuplicateQuestions(string question, Nullable<int> templateID, Nullable<int> questionOrder)
        {
            var questionParameter = question != null ?
                new ObjectParameter("Question", question) :
                new ObjectParameter("Question", typeof(string));
    
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("TemplateID", templateID) :
                new ObjectParameter("TemplateID", typeof(int));
    
            var questionOrderParameter = questionOrder.HasValue ?
                new ObjectParameter("QuestionOrder", questionOrder) :
                new ObjectParameter("QuestionOrder", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_QuestionBindingAndCreateDuplicateQuestions", questionParameter, templateIDParameter, questionOrderParameter);
        }
    
        public virtual int sp_SubjectQuestionBindingAndCreateDuplicateQuestions(string question, Nullable<int> templateID, Nullable<int> questionOrder)
        {
            var questionParameter = question != null ?
                new ObjectParameter("Question", question) :
                new ObjectParameter("Question", typeof(string));
    
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("TemplateID", templateID) :
                new ObjectParameter("TemplateID", typeof(int));
    
            var questionOrderParameter = questionOrder.HasValue ?
                new ObjectParameter("QuestionOrder", questionOrder) :
                new ObjectParameter("QuestionOrder", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_SubjectQuestionBindingAndCreateDuplicateQuestions", questionParameter, templateIDParameter, questionOrderParameter);
        }
    
        public virtual int sp_updatePersonalTemplate(string context, string templateDescription, string subject, string templateTItle, Nullable<int> templateID)
        {
            var contextParameter = context != null ?
                new ObjectParameter("Context", context) :
                new ObjectParameter("Context", typeof(string));
    
            var templateDescriptionParameter = templateDescription != null ?
                new ObjectParameter("TemplateDescription", templateDescription) :
                new ObjectParameter("TemplateDescription", typeof(string));
    
            var subjectParameter = subject != null ?
                new ObjectParameter("subject", subject) :
                new ObjectParameter("subject", typeof(string));
    
            var templateTItleParameter = templateTItle != null ?
                new ObjectParameter("templateTItle", templateTItle) :
                new ObjectParameter("templateTItle", typeof(string));
    
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_updatePersonalTemplate", contextParameter, templateDescriptionParameter, subjectParameter, templateTItleParameter, templateIDParameter);
        }
    
        public virtual int sp_deletePersonalSubejctByTemplate(Nullable<int> templateID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_deletePersonalSubejctByTemplate", templateIDParameter);
        }
    
        public virtual int sp_DeleteUserTemplateQuestionByTemp(Nullable<int> templateID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteUserTemplateQuestionByTemp", templateIDParameter);
        }
    
        public virtual int sp_PersonalQuestionBindingAndCreateDuplicateQuestions(string question, Nullable<int> templateID, Nullable<int> questionOrder)
        {
            var questionParameter = question != null ?
                new ObjectParameter("Question", question) :
                new ObjectParameter("Question", typeof(string));
    
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("TemplateID", templateID) :
                new ObjectParameter("TemplateID", typeof(int));
    
            var questionOrderParameter = questionOrder.HasValue ?
                new ObjectParameter("QuestionOrder", questionOrder) :
                new ObjectParameter("QuestionOrder", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_PersonalQuestionBindingAndCreateDuplicateQuestions", questionParameter, templateIDParameter, questionOrderParameter);
        }
    
        public virtual int sp_PersonalSubjectQuestionBindingAndCreateDuplicateQuestions(string question, Nullable<int> templateID, Nullable<int> questionOrder)
        {
            var questionParameter = question != null ?
                new ObjectParameter("Question", question) :
                new ObjectParameter("Question", typeof(string));
    
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("TemplateID", templateID) :
                new ObjectParameter("TemplateID", typeof(int));
    
            var questionOrderParameter = questionOrder.HasValue ?
                new ObjectParameter("QuestionOrder", questionOrder) :
                new ObjectParameter("QuestionOrder", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_PersonalSubjectQuestionBindingAndCreateDuplicateQuestions", questionParameter, templateIDParameter, questionOrderParameter);
        }
    
        public virtual ObjectResult<SP_PersonalQuestionByTemplateAndType_Result> SP_PersonalQuestionByTemplateAndType(Nullable<int> templateID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("TemplateID", templateID) :
                new ObjectParameter("TemplateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_PersonalQuestionByTemplateAndType_Result>("SP_PersonalQuestionByTemplateAndType", templateIDParameter);
        }
    
        public virtual ObjectResult<string> sp_PersonalSubjectQuestionContentbyTemplateID(Nullable<int> templateID)
        {
            var templateIDParameter = templateID.HasValue ?
                new ObjectParameter("templateID", templateID) :
                new ObjectParameter("templateID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_PersonalSubjectQuestionContentbyTemplateID", templateIDParameter);
        }
    
        public virtual int sp_deleteUserInfobyID(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_deleteUserInfobyID", userIDParameter);
        }
    
        public virtual int sp_UPdateUserInfobyID(Nullable<int> userID, Nullable<int> country, string industry, string company, string jobtitle, string tel, string fax, string lastName, string firstName, Nullable<int> gender, Nullable<int> userTitle)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var countryParameter = country.HasValue ?
                new ObjectParameter("country", country) :
                new ObjectParameter("country", typeof(int));
    
            var industryParameter = industry != null ?
                new ObjectParameter("industry", industry) :
                new ObjectParameter("industry", typeof(string));
    
            var companyParameter = company != null ?
                new ObjectParameter("company", company) :
                new ObjectParameter("company", typeof(string));
    
            var jobtitleParameter = jobtitle != null ?
                new ObjectParameter("Jobtitle", jobtitle) :
                new ObjectParameter("Jobtitle", typeof(string));
    
            var telParameter = tel != null ?
                new ObjectParameter("Tel", tel) :
                new ObjectParameter("Tel", typeof(string));
    
            var faxParameter = fax != null ?
                new ObjectParameter("Fax", fax) :
                new ObjectParameter("Fax", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var genderParameter = gender.HasValue ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(int));
    
            var userTitleParameter = userTitle.HasValue ?
                new ObjectParameter("UserTitle", userTitle) :
                new ObjectParameter("UserTitle", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UPdateUserInfobyID", userIDParameter, countryParameter, industryParameter, companyParameter, jobtitleParameter, telParameter, faxParameter, lastNameParameter, firstNameParameter, genderParameter, userTitleParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_UserInfoIDbyAspUserName(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_UserInfoIDbyAspUserName", userNameParameter);
        }
    
        public virtual int ResetPassword(string newPassword, string email)
        {
            var newPasswordParameter = newPassword != null ?
                new ObjectParameter("newPassword", newPassword) :
                new ObjectParameter("newPassword", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ResetPassword", newPasswordParameter, emailParameter);
        }
    }
}

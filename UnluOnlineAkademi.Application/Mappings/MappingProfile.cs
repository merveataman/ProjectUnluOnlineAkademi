using AutoMapper;
using UnluOnlineAkademi.Application.AboutUs.Commands.CreateAboutUsCommand;
using UnluOnlineAkademi.Application.AboutUs.Commands.DeleteAboutUsCommand;
using UnluOnlineAkademi.Application.AboutUs.Commands.UpdateAboutUsCommand;
using UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsById;
using UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsList;
using UnluOnlineAkademi.Application.Achievements.Commands.CreateAchievementsCommand;
using UnluOnlineAkademi.Application.Achievements.Commands.DeleteAchievementsCommand;
using UnluOnlineAkademi.Application.Achievements.Commands.UpdateAchievementsCommand;
using UnluOnlineAkademi.Application.Achievements.Queries.AchievementsById;
using UnluOnlineAkademi.Application.Achievements.Queries.AchievementsGetList;
using UnluOnlineAkademi.Application.Blog.Commands.CreateBlogCommand;
using UnluOnlineAkademi.Application.Blog.Commands.DeleteBlogCommand;
using UnluOnlineAkademi.Application.Blog.Commands.UpdateBlogCommand;
using UnluOnlineAkademi.Application.Blog.Queries.BlogById;
using UnluOnlineAkademi.Application.Blog.Queries.BlogGetList;
using UnluOnlineAkademi.Application.ContactInfo.Commands.CreateContactInfoCommand;
using UnluOnlineAkademi.Application.ContactInfo.Commands.DeleteContactInfoCommand;
using UnluOnlineAkademi.Application.ContactInfo.Commands.UpdateContactInfoCommand;
using UnluOnlineAkademi.Application.ContactInfo.Queries.ContactInfoById;
using UnluOnlineAkademi.Application.ContactInfo.Queries.ContactInfoGetList;
using UnluOnlineAkademi.Application.ContactOptions.Commands.CreateContactOptionsCommand;
using UnluOnlineAkademi.Application.ContactOptions.Commands.DeleteContactOptionsCommand;
using UnluOnlineAkademi.Application.ContactOptions.Commands.UpdateContactOptionsCommand;
using UnluOnlineAkademi.Application.ContactOptions.Queries.ContactOptionsById;
using UnluOnlineAkademi.Application.ContactOptions.Queries.ContactOptionsGetList;
using UnluOnlineAkademi.Application.CourseCategory.Commands.CreateCourseCategoryCommand;
using UnluOnlineAkademi.Application.CourseCategory.Commands.DeleteCourseCategoryCommand;
using UnluOnlineAkademi.Application.CourseCategory.Commands.UpdateCourseCategoryCommand;
using UnluOnlineAkademi.Application.CourseCategory.Queries.CourseCategoryById;
using UnluOnlineAkademi.Application.CourseCategory.Queries.CourseCategoryGetList;
using UnluOnlineAkademi.Application.CourseLessons.Commands.CreateCourseLessonsCommand;
using UnluOnlineAkademi.Application.CourseLessons.Commands.DeleteCourseLessonsCommand;
using UnluOnlineAkademi.Application.CourseLessons.Commands.UpdateCourseLessonsCommand;
using UnluOnlineAkademi.Application.CourseLessons.Queries.CourseLessonsById;
using UnluOnlineAkademi.Application.CourseLessons.Queries.CourseLessonsGetList;
using UnluOnlineAkademi.Application.EducationalContent.Commands.CreateEducationalContentCommand;
using UnluOnlineAkademi.Application.EducationalContent.Commands.DeleteEducationalContentCommand;
using UnluOnlineAkademi.Application.EducationalContent.Commands.UpdateEducationalContentCommand;
using UnluOnlineAkademi.Application.EducationalContent.Queries.EducationalContentById;
using UnluOnlineAkademi.Application.EducationalContent.Queries.EducationalContentGetList;
using UnluOnlineAkademi.Application.MailList.Commands.CreateMailListCommand;
using UnluOnlineAkademi.Application.MailList.Commands.DeleteMailListCommand;
using UnluOnlineAkademi.Application.MailList.Commands.UpdateMailListCommand;
using UnluOnlineAkademi.Application.MailList.Queries.MailListById;
using UnluOnlineAkademi.Application.MailList.Queries.MailListList;
using UnluOnlineAkademi.Application.Policies.Commands.CreatePoliciesCommand;
using UnluOnlineAkademi.Application.Policies.Commands.DeletePoliciesCommand;
using UnluOnlineAkademi.Application.Policies.Commands.UpdatePoliciesCommand;
using UnluOnlineAkademi.Application.Policies.Queries.PoliciesById;
using UnluOnlineAkademi.Application.Policies.Queries.PoliciesList;
using UnluOnlineAkademi.Application.SSS.Commands.CreateSSSCommand;
using UnluOnlineAkademi.Application.SSS.Commands.DeleteSSSCommand;
using UnluOnlineAkademi.Application.SSS.Commands.UpdateSSSCommand;
using UnluOnlineAkademi.Application.SSS.Queries.SSSById;
using UnluOnlineAkademi.Application.SSS.Queries.SSSList;
using UnluOnlineAkademi.Application.StudentTestimonial.Commands.CreateStudentTestimonialCommand;
using UnluOnlineAkademi.Application.StudentTestimonial.Commands.DeleteStudentTestimonialCommand;
using UnluOnlineAkademi.Application.StudentTestimonial.Commands.UpdateStudentTestimonialCommand;
using UnluOnlineAkademi.Application.StudentTestimonial.Queries.StudentTestimonialById;
using UnluOnlineAkademi.Application.StudentTestimonial.Queries.StudentTestimonialList;
using UnluOnlineAkademi.Application.WhyUs.Commands.CreateWhyUsCommand;
using UnluOnlineAkademi.Application.WhyUs.Commands.DeleteWhyUsCommand;
using UnluOnlineAkademi.Application.WhyUs.Commands.UpdateWhyUsCommand;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsById;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsList;
using UnluOnlineAkademi.Domain.Entities;

namespace UnluOnlineAkademi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, AboutUsDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, AboutUsByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, CreateAboutUsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, UpdateAboutUsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, DeleteAboutUsCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.Achievements, AchievementsDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Achievements, AchievementsByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Achievements, CreateAchievementsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Achievements, UpdateAchievementsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Achievements, DeleteAchievementsCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.Blog, BlogDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Blog, BlogByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Blog, UpdateBlogCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Blog, DeleteBlogCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.ContactInfos, ContactInfoDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.ContactInfos, ContactInfoByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.ContactInfos, CreateContactInfoCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.ContactInfos, UpdateContactInfoCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.ContactInfos, DeleteContactInfoCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.ContactOptions, ContactOptionsDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.ContactOptions, ContactOptionsByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.ContactOptions, CreateContactOptionsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.ContactOptions, UpdateContactOptionsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.ContactOptions, DeleteContactOptionsCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.CourseCategory, CourseCategoryDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.CourseCategory, CourseCategoryByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.CourseCategory, CreateCourseCategoryCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.CourseCategory, UpdateCourseCategoryCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.CourseCategory, DeleteCourseCategoryCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.CourseLessons, CourseLessonsDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.CourseLessons, CourseLessonsByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.CourseLessons, CreateCourseLessonsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.CourseLessons, UpdateCourseLessonsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.CourseLessons, DeleteCourseLessonsCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.EducationalContent, EducationalContentDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.EducationalContent, EducationalContentByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.EducationalContent, CreateEducationalContentCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.EducationalContent, UpdateEducationalContentCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.EducationalContent, DeleteEducationalContentCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.WhyUs, WhyUsDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.WhyUs, WhyUsByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.WhyUs, CreateWhyUsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.WhyUs, UpdateWhyUsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.WhyUs, DeleteWhyUsCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.StudentTestimonial, StudentTestimonialDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.StudentTestimonial, StudentTestimonialByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.StudentTestimonial, CreateStudentTestimonialCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.StudentTestimonial, UpdateStudentTestimonialCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.StudentTestimonial, DeleteStudentTestimonialCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.SSS, SSSDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.SSS, SSSByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.SSS, CreateSSSCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.SSS, UpdateSSSCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.SSS, DeleteSSSCommand>().ReverseMap();


            CreateMap<UnluOnlineAkademi.Domain.Entities.Policies, PoliciesDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Policies, PoliciesByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Policies, CreatePoliciesCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Policies, UpdatePoliciesCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Policies, DeletePoliciesCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.MailList, MailListDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.MailList, MailListByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.MailList, CreateMailListCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.MailList, UpdateMailListCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.MailList, DeleteMailListCommand>().ReverseMap();
        }
    }
}

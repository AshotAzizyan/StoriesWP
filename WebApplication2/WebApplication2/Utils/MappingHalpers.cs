using AutoMapper;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.ModelsGroupController;
using WebApplication2.Models.ModelsStoryController;
using WebApplication2.Models.ModelsUserController;

namespace WebApplication2.Utils
{
    public static class MappingHalpers
    {
        public static List<SubGroupIndexModel> GroupToSubGroupIndexModel(IEnumerable<Group> groups)
        {
            Mapper.Initialize(c => c.CreateMap<Group, SubGroupIndexModel>());
            return Mapper.Map<IEnumerable<Group>, List<SubGroupIndexModel>>(groups);
        }
        public static IEnumerable<Group> SubGroupIndexModelToGroup(List<SubGroupIndexModel> groups)
        {
            Mapper.Initialize(c => c.CreateMap< SubGroupIndexModel, Group>());
            return Mapper.Map< List<SubGroupIndexModel>, IEnumerable<Group>>(groups);
        }
        public static Story CreateStoryViewModelToStory(CreateStoryViewModel story)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CreateStoryViewModel, Story>());
            return   Mapper.Map<CreateStoryViewModel, Story>(story);
        }
        public static CreateStoryViewModel StoryToCreateStoryViewModel(Story story)
        {
            Mapper.Initialize(cfg => cfg.CreateMap< Story, CreateStoryViewModel>());
            return Mapper.Map< Story, CreateStoryViewModel>(story);
        }
        public static EditStoryViewModel StoryToEditStoryViewModel( Story story)
        {
            Mapper.Initialize(c => c.CreateMap<Story, EditStoryViewModel>());
            return  Mapper.Map<Story, EditStoryViewModel>(story);
        }
        public static Story EditStoryViewModelToStory(EditStoryViewModel story)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EditStoryViewModel, Story>());
            return  Mapper.Map<EditStoryViewModel, Story>(story);
        }
        public static DetailsStoryViewModel StoryToDetailsStoryViewModel(Story story)
        {
            Mapper.Initialize(c => c.CreateMap<Story, DetailsStoryViewModel>());
            return Mapper.Map<Story, DetailsStoryViewModel>(story);
        }
        public static Story DetailsStoryViewModelToStory(DetailsStoryViewModel story)
        {
            Mapper.Initialize(c => c.CreateMap<DetailsStoryViewModel,Story>());
            return Mapper.Map<DetailsStoryViewModel,Story>(story);
        }
        public static List<SubStoryIndexModel> StoryToSubStoryIndexModel(IEnumerable<Story> stories)
        {
            Mapper.Initialize(c => c.CreateMap<Story, SubStoryIndexModel>());

            return Mapper.Map<IEnumerable<Story>, List<SubStoryIndexModel>>(stories);
        }
        public  static IEnumerable<Story> SubStoryIndexModelToStory(List<SubStoryIndexModel> stories)
        {
            Mapper.Initialize(c => c.CreateMap< SubStoryIndexModel, Story>());

            return Mapper.Map<List<SubStoryIndexModel>, IEnumerable<Story>>(stories);
        }
        public static List<UserIndexModel>  UserToUserIndexModel(IEnumerable<User> users)
        {
            Mapper.Initialize(c => c.CreateMap<User, UserIndexModel>());
            return  Mapper.Map<IEnumerable<User>, List<UserIndexModel>>(users);
        }
        public static User UserIndexModelToUser(UserIndexModel user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserIndexModel, User>());
            return Mapper.Map<UserIndexModel, User>(user);
        }
    }
}
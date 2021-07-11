using AutoMapper;
using Calculator.Models;
using Calculator.Models.ViewModels;
namespace Calculator.Models.Mappings
{
    public class DomainToViewModelMappingProfileGen : Profile
    {
        public override string ProfileName {
        get { return "DomainToViewModelMappingsGen"; }
        }
        public DomainToViewModelMappingProfileGen ()
        {
            CreateMap<ActiveBusinessData,ActiveBusinessDataVM>().ReverseMap();
            CreateMap<ActiveUserData,ActiveUserDataVM>().ReverseMap();
            CreateMap<ActiveWebPageData,ActiveWebPageDataVM>().ReverseMap();
            CreateMap<Business,BusinessVM>().ReverseMap();
            CreateMap<Chat,ChatVM>().ReverseMap();
            CreateMap<ChatEntry,ChatEntryVM>().ReverseMap();
            CreateMap<ChatIndividual,ChatIndividualVM>().ReverseMap();
            CreateMap<Individual,IndividualVM>().ReverseMap();
            CreateMap<IndividualInBusiness,IndividualInBusinessVM>().ReverseMap();
            CreateMap<LookupCategory,LookupCategoryVM>().ReverseMap();
            CreateMap<LookupType,LookupTypeVM>().ReverseMap();
            CreateMap<PageInteraction,PageInteractionVM>().ReverseMap();
            CreateMap<PageLoad,PageLoadVM>().ReverseMap();
            CreateMap<Calculator2Character,Calculator2CharacterVM>().ReverseMap();
            CreateMap<Room,RoomVM>().ReverseMap();
            CreateMap<UserInRoom,UserInRoomVM>().ReverseMap();
            CreateMap<WebContent,WebContentVM>().ReverseMap();
            CreateMap<WebContentDocument,WebContentDocumentVM>().ReverseMap();
            CreateMap<WebContentItem,WebContentItemVM>().ReverseMap();
            CreateMap<WebContentUrl,WebContentUrlVM>().ReverseMap();
            CreateMap<WebContentVideo,WebContentVideoVM>().ReverseMap();
            CreateMap<WebForm,WebFormVM>().ReverseMap();
            CreateMap<WebFormVersion,WebFormVersionVM>().ReverseMap();
            CreateMap<WebPage,WebPageVM>().ReverseMap();
            CreateMap<Website,WebsiteVM>().ReverseMap();
            CreateMap<WebsiteAlias,WebsiteAliasVM>().ReverseMap();
        }
    }
}

namespace Butterfly.Communication.Packets.Outgoing
{
    public static class ServerPacketHeader
    {
        // Handshake 
        public const int InitCryptoMessageComposer = 1895;
        public const int SecretKeyMessageComposer = 156;
        public const int AuthenticationOKMessageComposer = 41;
        public const int UserObjectMessageComposer = 1950;
        public const int UserPerksMessageComposer = 3067;
        public const int UserRightsMessageComposer = 3918;
        public const int GenericErrorMessageComposer = 1321;
        public const int SetUniqueIdMessageComposer = 2270;
        public const int AvailabilityStatusMessageComposer = 3209;
        public const int BuildersClubMembershipMessageComposer = 3997;

        // Avatar
        public const int WardrobeMessageComposer = 1343;
        public const int FavouritesMessageComposer = 2761;
        public const int AvatarEffectsMessageComposer = 365;

        public const int NuxAlertMessageComposer = 78;
        public const int NuxUserStatusMessageComposer = 2893;

        // Navigator
        public const int NavigatorSettingsMessageComposer = 3323;
        public const int NavigatorLiftedRoomsMessageComposer = 1392;
        public const int NavigatorPreferencesMessageComposer = 2981;
        public const int NavigatorFlatCatsMessageComposer = 745;
        public const int NavigatorMetaDataParserMessageComposer = 1302;
        public const int NavigatorCollapsedCategoriesMessageComposer = 3984;
        public const int NavigatorSearchResultSetMessageComposer = 813;

        //FriendList
        public const int MessengerInitMessageComposer = 2497;
        public const int FriendListUpdateMessageComposer = 100;

        // Messenger
        public const int BuddyListMessageComposer = 2399;

        // Notifications
        public const int ActivityPointsMessageComposer = 2791;
        public const int HabboActivityPointNotificationMessageComposer = 48;

        //Inventory
        public const int CreditBalanceMessageComposer = 1860;

        // Moderation
        public const int ModeratorInitMessageComposer = 2998;
        public const int CfhTopicsInitMessageComposer = 2010;


        public const int HelperToolMessageComposer = 1;
        public const int OnGuideSessionStarted = 2326;
        public const int OnGuideSessionPartnerIsTyping = 1929;
        public const int OnGuideSessionMsg = 102;
        public const int OnGuideSessionInvitedToGuideRoom = 3556;
        public const int OnGuideSessionRequesterRoom = 478;
        public const int OnGuideSessionEnded = 2554;
        public const int OnGuideSessionAttached = 842;
        public const int OnGuideSessionDetached = 633;
        public const int OnGuideSessionError = 1085;

        public const int FloorPlanSendDoorMessageComposer = 885;
        public const int FloorPlanFloorMapMessageComposer = 3103;

        public const int CampaignMessageComposer = 1701;
        public const int PromoArticlesMessageComposer = 1452;

        // Sound
        public const int SoundSettingsMessageComposer = 2468;

        public const int ScrSendUserInfoMessageComposer = 3531;
        public const int GetRelationshipsMessageComposer = 3871;
        public const int CatalogOfferMessageComposer = 1303;
        public const int TalentTrackLevelMessageComposer = 3701;
        public const int FurnitureAliasesMessageComposer = 2274;
        public const int GiftWrappingConfigurationMessageComposer = 3609;
        public const int RoomChatOptionsComposer = 2494;
        public const int CatalogItemDiscountMessageComposer = 1462;
        public const int BCBorrowedItemsMessageComposer = 1173;
        public const int LatencyResponseMessageComposer = 3831;
        public const int UpdateFavouriteRoomMessageComposer = 67;
        public const int ProfileInformationMessageComposer = 2505;
        public const int GuestRoomSearchResultMessageComposer = 3187;
        public const int CatalogIndexMessageComposer = 2612;
        public const int CatalogPageMessageComposer = 1763;
        public const int SellablePetBreedsMessageComposer = 3709;
        public const int CheckPetNameMessageComposer = 2918;
        public const int CatalogUpdatedMessageComposer = 1318;

        public const int FigureSetIdsMessageComposer = 3091;
        public const int LoveLockDialogueCloseMessageComposer = 2534;
        public const int LoveLockDialogueSetLockedMessageComposer = 2534;
        public const int LoveLockDialogueMessageComposer = 1749;
        public const int UnbanUserFromRoomMessageComposer = 2839;
        public const int UserTagsMessageComposer = 1853;
        public const int AchievementsMessageComposer = 1134;
        public const int AchievementScoreMessageComposer = 2006;
        public const int AchievementProgressedMessageComposer = 3653;
        public const int AchievementUnlockedMessageComposer = 2324;
        public const int BroadcastMessageAlertMessageComposer = 3346;
        public const int RoomNotificationMessageComposer = 1900;
        public const int MOTDNotificationMessageComposer = 2606;
        public const int ModResponse = 170;
        public const int PetHorseFigureInformationMessageComposer = 2376;
        public const int PetTrainingPanelMessageComposer = 149;
        public const int FurniListUpdateMessageComposer = 1206;
        public const int PurchaseOKMessageComposer = 584;
        public const int FurniListNotificationMessageComposer = 2050;
        public const int PublicCategories = 3541;
        public const int AvatarEffectAddedMessageComposer = 2731;
        public const int AvatarEffectActivatedMessageComposer = 1457;
        public const int AvatarEffectExpiredMessageComposer = 2614;
        public const int OpenHelpToolMessageComposer = 2682;
        public const int CanCreateRoomMessageComposer = 2744;
        public const int FlatCreatedMessageComposer = 776;
        public const int RoomSettingsDataMessageComposer = 911;
        public const int RoomSettingsSavedMessageComposer = 2758;
        public const int CantConnectMessageComposer = 1703;
        public const int CloseConnectionMessageComposer = 378;
        public const int FlatAccessDeniedMessageComposer = 2384;
        public const int DoorbellMessageComposer = 2660;
        public const int FlatAccessibleMessageComposer = 1915;
        public const int BuddyRequestsMessageComposer = 2752;
        public const int NewBuddyRequestMessageComposer = 951;
        public const int NewConsoleMessageMessageComposer = 3791;
        public const int RoomInviteMessageComposer = 678;
        public const int InstantMessageErrorMessageComposer = 1472;
        public const int RoomReadyMessageComposer = 329;
        public const int RoomForwardMessageComposer = 732;
        public const int HabboSearchResultMessageComposer = 2701;

        public const int TradingStartMessageComposer = 425;
        public const int TradingUpdateMessageComposer = 1243;
        public const int TradingAcceptMessageComposer = 3615;
        public const int TradingCompleteMessageComposer = 3902;
        public const int TradingFinishMessageComposer = 3731;
        public const int TradingClosedMessageComposer = 1166;

        public const int RoomPropertyMessageComposer = 3235;
        public const int YouAreControllerMessageComposer = 2613;
        public const int YouAreOwnerMessageComposer = 1031;
        public const int YouAreNotControllerMessageComposer = 2407;

        public const int RoomRatingMessageComposer = 1798;
        public const int FloorHeightMapMessageComposer = 2434;
        public const int HeightMapMessageComposer = 2604;
        public const int OpenGiftMessageComposer = 3166;
        public const int ObjectsMessageComposer = 473;
        public const int ItemsMessageComposer = 3120;
        public const int FloodControlMessageComposer = 3327;
        public const int UsersMessageComposer = 3315;
        public const int RoomVisualizationSettingsMessageComposer = 2109;
        public const int RoomEntryInfoMessageComposer = 3277;
        public const int GetGuestRoomResultMessageComposer = 2974;
        public const int UserUpdateMessageComposer = 2658;
        public const int UserFlatCatsMessageComposer = 462;
        public const int ChatMessageComposer = 2398;
        public const int ShoutMessageComposer = 430;
        public const int WhisperMessageComposer = 2814;
        public const int IgnoreStatusMessageComposer = 369;
        public const int RespectNotificationMessageComposer = 3419;
        public const int UserChangeMessageComposer = 3606;
        public const int DanceMessageComposer = 3427;
        public const int ActionMessageComposer = 2783;
        public const int SleepMessageComposer = 1021;
        public const int FurniListMessageComposer = 1332;
        public const int FurniListAddMessageComposer = 275;
        public const int PetInventoryMessageComposer = 1380;
        public const int PetInformationMessageComposer = 756;
        public const int RespectPetNotificationMessageComposer = 1098;
        public const int NotifyNewPetLevelMessageComposer = 3205;
        public const int AddExperiencePointsMessageComposer = 713;
        public const int BadgesMessageComposer = 2977;
        public const int HabboUserBadgesMessageComposer = 1978;
        public const int ReceiveBadgeMessageComposer = 3423;
        public const int FlatControllerAddedMessageComposer = 3288;
        public const int FlatControllerRemovedMessageComposer = 3000;
        public const int RoomRightsListMessageComposer = 2269;
        public const int GetRoomBannedUsersMessageComposer = 3863;
        public const int UserTypingMessageComposer = 13;
        public const int FurniListRemoveMessageComposer = 1051;

        public const int ObjectAddMessageComposer = 2057;
        public const int ItemAddMessageComposer = 3864;

        public const int ObjectUpdateMessageComposer = 174;
        public const int ItemUpdateMessageComposer = 1052;
        public const int ObjectRemoveMessageComposer = 1096;
        public const int ItemRemoveMessageComposer = 139;

        public const int WiredTriggerConfigMessageComposer = 2194;
        public const int WiredEffectConfigMessageComposer = 2530;
        public const int WiredConditionConfigMessageComposer = 2300;
        public const int SaveWired = 2560;
        public const int GroupFurniSettingsMessageComposer = 1215;

        public const int UserRemoveMessageComposer = 2198;
        public const int ModeratorRoomInfoMessageComposer = 3048;
        public const int ModeratorUserInfoMessageComposer = 3683;
        public const int ModeratorRoomChatlogMessageComposer = 1692;
        public const int ModeratorUserChatlogMessageComposer = 3607;
        public const int ModeratorTicketChatlogMessageComposer = 3450;
        public const int ModeratorSupportTicketMessageComposer = 701;
        public const int AvatarEffectMessageComposer = 692;
        public const int CarryObjectMessageComposer = 3138;
        public const int SlideObjectBundleMessageComposer = 3371;
        public const int MoodlightConfigMessageComposer = 444;
        public const int StickyNoteMessageComposer = 2490;
        public const int UpdateFreezeLives = 379;

        public const int QuestListMessageComposer = 3532;
        public const int QuestStartedMessageComposer = 1195;
        public const int QuestAbortedMessageComposer = 3397;
        public const int QuestCompletedMessageComposer = 1880;
        public const int UserNameChangeMessageComposer = 1232;
        public const int NameChangeUpdateMessageComposer = 1686;
        public const int RoomInfoUpdatedMessageComposer = 1328;

        public const int UnknownGroupMessageComposer = 3160;
        public const int GroupCreationWindowMessageComposer = 1799;
        public const int BadgeEditorPartsMessageComposer = 2138;
        public const int RefreshFavouriteGroupMessageComposer = 942;
        public const int NewGroupInfoMessageComposer = 2199;
        public const int GroupFurniConfigMessageComposer = 708;
        public const int HabboGroupBadgesMessageComposer = 2999;
        public const int GroupInfoMessageComposer = 248;
        public const int ManageGroupMessageComposer = 3764;
        public const int GroupMembershipRequestedMessageComposer = 1401;
        public const int GroupMembersMessageComposer = 1252;
        public const int SetGroupIdMessageComposer = 1563;
        public const int UpdateFavouriteGroupMessageComposer = 2970;
        public const int GroupMemberUpdatedMessageComposer = 2666;
        public const int BotInventoryMessageComposer = 824;
        public const int OpenBotActionMessageComposer = 1831;
        public const int GroupAreYouSureMessageComposer = 213;

        public const int VoucherRedeemErrorMessageComposer = 2857;

        public const int MarketPlaceOffersMessageComposer = 1766;
        public const int MarketplaceCancelOfferResultMessageComposer = 3991;
        public const int MarketplaceMakeOfferResultMessageComposer = 1664;
        public const int MarketplaceCanMakeOfferResultMessageComposer = 1503;
        public const int MarketplaceItemStatsMessageComposer = 1310;
        public const int MarketPlaceOwnOffersMessageComposer = 1309;
        public const int MarketplaceConfigurationMessageComposer = 802;

        public const int UpdateUsernameMessageComposer = 1709;
    }
}

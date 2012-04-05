using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TrelloNet.Internal
{
	internal class ActionConverter : JsonCreationConverter<Action>
	{
		private static readonly Dictionary<string, Func<Action>> TypeMap = new Dictionary<string, Func<Action>>
		{
			{ "createCard", () => new CreateCardAction() },
			{ "commentCard", () => new CommentCardAction() },
			{ "addMemberToCard", () => new AddMemberToCardAction() },
			{ "removeMemberFromCard", () => new RemoveMemberFromCardAction() },			
			{ "updateCheckItemStateOnCard", () => new UpdateCheckItemStateOnCardAction() },			
			{ "addAttachmentToCard", () => new AddAttachmentToCardAction() },
			{ "deleteAttachmentFromCard", () => new DeleteAttachmentFromCardAction() },
			{ "addChecklistToCard", () => new AddChecklistToCardAction() },
			{ "removeChecklistFromCard", () => new RemoveChecklistFromCardAction() },
			{ "createList", () => new CreateListAction() },			
			{ "createBoard", () => new CreateBoardAction() },
			{ "addMemberToBoard", () => new AddMemberToBoardAction() },
			{ "removeMemberFromBoard", () => new RemoveMemberFromBoardAction() },
			{ "addToOrganizationBoard", () => new AddToOrganizationBoardAction() },
			{ "removeFromOrganizationBoard", () => new RemoveFromOrganizationBoardAction() },
			{ "createOrganization", () => new CreateOrganizationAction() },
			{ "updateOrganization", () => new UpdateOrganizationAction() }
		};

		protected override Action Create(Type objectType, JObject jObject)
		{
			Func<Action> specificAction;
			if (TypeMap.TryGetValue(ParseType(jObject), out specificAction))
				return specificAction();

			return new Action();
		}

		private static string ParseType(JObject jObject)
		{
			return jObject["type"].ToObject<string>();
		}
	}
}
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TrelloNet.Internal
{
	internal class ActionConverter : JsonCreationConverter<Action>
	{
		private static readonly Dictionary<string, Func<JObject, Action>> TypeMap = new Dictionary<string, Func<JObject, Action>>
		{
			{ "createCard", _ => new CreateCardAction() },
			{ "commentCard", _ => new CommentCardAction() },
			{ "addMemberToCard", _ => new AddMemberToCardAction() },
			{ "removeMemberFromCard", _ => new RemoveMemberFromCardAction() },			
			{ "updateCheckItemStateOnCard", _ => new UpdateCheckItemStateOnCardAction() },			
			{ "addAttachmentToCard", _ => new AddAttachmentToCardAction() },
			{ "deleteAttachmentFromCard", _ => new DeleteAttachmentFromCardAction() },
			{ "addChecklistToCard", _ => new AddChecklistToCardAction() },
			{ "removeChecklistFromCard", _ => new RemoveChecklistFromCardAction() },
			{ "createList", _ => new CreateListAction() },			
			{ "createBoard", _ => new CreateBoardAction() },
			{ "addMemberToBoard", _ => new AddMemberToBoardAction() },
			{ "removeMemberFromBoard", _ => new RemoveMemberFromBoardAction() },
			{ "addToOrganizationBoard", _ => new AddToOrganizationBoardAction() },
			{ "removeFromOrganizationBoard", _ => new RemoveFromOrganizationBoardAction() },
			{ "createOrganization", _ => new CreateOrganizationAction() },
			{ "updateBoard", CreateUpdateBoardAction },
			{ "updateCard", CreateUpdateCardAction },
			{ "updateList", CreateUpdateListAction },
			{ "updateOrganization", CreateUpdateOrganizationAction },
			{ "moveCardToBoard", _ => new MoveCardToBoardAction() },
		};

		private static Action CreateUpdateOrganizationAction(JObject jObject)
		{
			var action = new UpdateOrganizationAction();
			ApplyUpdateData(action.Data, jObject);
			return action;
		}

		private static Action CreateUpdateListAction(JObject jObject)
		{
			var action = new UpdateListAction();
			ApplyUpdateData(action.Data, jObject);
			return action;
		}

		private static Action CreateUpdateBoardAction(JObject jObject)
		{
			var action = new UpdateBoardAction();
			ApplyUpdateData(action.Data, jObject);
			return action;
		}

		private static Action CreateUpdateCardAction(JObject jObject)
		{
			if (jObject["data"]["listBefore"] != null)
				return new UpdateCardMoveAction();

			var action = new UpdateCardAction();
			ApplyUpdateData(action.Data, jObject);
			return action;
		}

		private static void ApplyUpdateData(IUpdateData updateData, JObject jObject)
		{
			var old = jObject["data"]["old"];

			if (old != null)
			{
				var updatedProperty = ((JProperty)old.First).Name;

				updateData.Old = new Old
				{
					PropertyName = updatedProperty,
					Value = old[updatedProperty]
				};
			}
		}

		protected override Action Create(Type objectType, JObject jObject)
		{
			Func<JObject, Action> specificAction;
			var type = ParseType(jObject);

			if (TypeMap.TryGetValue(type, out specificAction))
				return specificAction(jObject);

			return new Action();
		}

		private static string ParseType(JObject jObject)
		{
			return jObject["type"].ToObject<string>();
		}
	}
}
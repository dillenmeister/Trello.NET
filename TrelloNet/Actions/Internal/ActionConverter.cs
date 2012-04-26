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
			{ "updateCard", CreateUpdateCardAction }
		};

		private static Action CreateUpdateCardAction(JObject jObject)
		{			
			if (CanConvertToUpdateCardAction(jObject))
			{
				var action = new UpdateCardAction();
				ApplyUpdateData(action.Data, "card", jObject);
				return action;
			}

			if(CanConvertToUpdateCardMoveAction(jObject))			
				return new UpdateCardMoveAction();			

			return new Action();
		}

		private static bool CanConvertToUpdateCardMoveAction(JObject jObject)
		{
			return jObject["data"]["listBefore"] != null;
		}

		private static bool CanConvertToUpdateCardAction(JObject jObject)
		{
			return jObject["data"]["old"] != null;
		}

		private static Action CreateUpdateBoardAction(JObject jObject)
		{
			var action = new UpdateBoardAction();

			ApplyUpdateData(action.Data, "board", jObject);

			return action;			
		}

		private static void ApplyUpdateData(IUpdateData updateData, string type, JObject jObject)
		{
			var data = jObject["data"];
			var old = data["old"];

			var updatedProperty = ((JProperty)old.First).Name;
			dynamic oldValue = old[updatedProperty];
			dynamic newValue = data[type][updatedProperty];

			updateData.UpdatedProperty = updatedProperty;
			updateData.OldValue = oldValue;
			updateData.NewValue = newValue;
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
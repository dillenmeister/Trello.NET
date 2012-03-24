using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TrelloNet.Internal
{
	internal class ActionConverter : JsonCreationConverter<Action>
	{
		private static readonly Dictionary<string, Func<Action>> TypeMap = new Dictionary<string, Func<Action>>
		{
			{ "removeMemberFromCard", () => new RemoveMemberFromCardAction() },
			{ "addMemberToCard", () => new AddMemberToCardAction() },
			{ "commentCard", () => new CommentCardAction() },
			{ "addAttachmentToCard", () => new AddAttachmentToCardAction() },
			{ "createBoard", () => new CreateBoardAction() },
			{ "createCard", () => new CreateCardAction() }

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
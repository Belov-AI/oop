using System;

namespace MapObjects
{
    public static class Interaction
    {
        public static void Make(Player player, object mapObject)
        {
            // Далее используйте сокращенный синтаксис преобразования типа:
            // mapObject is Dwelling dwellingObj
            // Он позволяет не производить множественных преобразований таких, как
            // ((Dwelling)mapObject).Owner = player.Id;
            // а сразу обращаться к объекту, если он является каким-то классом.
            // dwellingObj.Owner = player.Id;

            if (mapObject is Dwelling dwellingObj)
            {
                dwellingObj.Owner = player.Id;
                return;
            }

            // Перед выполнение задания используйте преобразование типа вместе с is
            // и избавьтесь от повторяющихся явных преобразований типа

            if (mapObject is Mine)
            {
                if (player.CanBeat(((Mine)mapObject).Army))
                {
                    ((Mine)mapObject).Owner = player.Id;
                    player.Consume(((Mine)mapObject).Treasure);
                }
                else player.Die();
                return;
            }

            if (mapObject is Creeps)
            {
                if (player.CanBeat(((Creeps)mapObject).Army))
                    player.Consume(((Creeps)mapObject).Treasure);
                else
                    player.Die();
                return;
            }

            if (mapObject is ResourcePile)
            {
                player.Consume(((ResourcePile)mapObject).Treasure);
                return;
            }

            if (mapObject is Wolves)
            {
                if (!player.CanBeat(((Wolves)mapObject).Army))
                    player.Die();
            }
        }
    }

}

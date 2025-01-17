namespace BachelorProject.GameLogic
{
    public enum QuestType
    {
        Fight,
        Find
    }

    public class Quest(string name, string objective, int targetAmount, QuestType questType,
        string targetEntity, Item reward, Action? eventOnCompletion = null)
    {
        public string Name { get; private set; } = name;
        public string Objective { get; private set; } = objective;
        public int Progress { get; private set; } = 0;
        public int TargetAmount { get; private set; } = targetAmount;
        public QuestType QuestType { get; private set; } = questType;
        public string TargetEntity { get; private set; } = targetEntity;
        public bool IsCompleted => Progress >= TargetAmount;
        public Item Reward { get; private set; } = reward;
        public Action? EventOnQuestCompletion { get; private set; } = eventOnCompletion;

        public void UpdateProgress(int amount)
        {
            if (IsCompleted)
            {
                Console.WriteLine($"Quest '{Name}' is already completed.");
                return;
            }

            Progress += amount;
            if (Progress > TargetAmount)
            {
                Progress = TargetAmount;
            }

            Console.WriteLine($"Progress Updated: {Progress}/{TargetAmount} {TargetEntity} for quest '{Name}'");

            if (IsCompleted)
            {
                CompleteQuest();
            }
        }

        private void CompleteQuest()
        {
            Console.WriteLine($"Quest '{Name}' completed! You received: {Reward}");
            EventOnQuestCompletion?.Invoke();
        }
    }
}

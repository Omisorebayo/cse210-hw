
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // Constructor used when loading a saved goal.
    public ChecklistGoal(
        string name,
        string description,
        int points,
        int amountCompleted,
        int target,
        int bonus)
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        // Do not allow points after the checklist is already complete.
        if (_amountCompleted >= _target)
        {
            return 0;
        }

        _amountCompleted++;

        int pointsEarned = GetPoints();

        // Give the bonus when the target is reached.
        if (_amountCompleted == _target)
        {
            pointsEarned += _bonus;
        }

        return pointsEarned;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";

        return $"{checkbox} {GetShortName()} -- {GetDescription()} " +
               $"-- Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetShortName()}|{GetDescription()}|" +
               $"{GetPoints()}|{_amountCompleted}|{_target}|{_bonus}";
    }
}
public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        bool breatheIn = true;

        while (DateTime.Now < endTime)
        {
            if (breatheIn)
            {
                Console.Write("\nBreathe in... ");
                ShowCountDown(4);
            }
            else
            {
                Console.Write("\nBreathe out... ");
                ShowCountDown(6);
            }

            breatheIn = !breatheIn;
        }

        DisplayEndingMessage();
    }
}
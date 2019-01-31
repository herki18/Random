namespace Random.Api
{
    public class RandomGenerator : IRandomGenerator
    {
        public int[] RandomIntArray(int size)
        {
            System.Random random = new System.Random();
            int[] numbers = new int[size];
            for (var index = 0; index < size; index++)
            {
                numbers[index] = index + 1;
            }

            for (int currentNumber = 0; currentNumber < size; currentNumber++)
            {
                int nextRandom = random.Next(size - currentNumber) + currentNumber;
                int temp = numbers[currentNumber];
                numbers[currentNumber] = numbers[nextRandom];
                numbers[nextRandom] = temp;
            }
            return numbers;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace NumberBaseballList
{
    public class Program
    {
        private static void Main(string[] args)
        {
            List<int> Quest = new List<int>();

            while (Quest.Count < 3)
            {
                Quest.Add(GetQuestNumber(Quest));

            }

            WriteLine($"정답 : {Quest[0]} , {Quest[1]} , {Quest[2]}");

            // 스트라이크와 볼을 저장할 변수 선언
            int strike = 0;
            int ball = 0;

            // 사용자 입력을 받아서 스트라이크와 볼을 계산하는 반복문
            do
            {
                WriteLine("\n세 자리 숫자를 입력하세요: ");
                string? answer = Console.ReadLine();

                // 입력값이 null이거나 길이가 3이 아닌 경우 처리
                if (string.IsNullOrEmpty(answer) || answer.Length != 3)
                {
                    WriteLine("\n세 자리 숫자를 입력해야 합니다.");
                    continue;
                }

                // 입력값이 숫자가 아니거나 범위를 벗어난 경우 처리
                if (!int.TryParse(answer, out int userInput) || userInput < 0 || userInput > 999)
                {
                    WriteLine("\n유효한 세 자리 숫자를 입력하세요.");
                    continue;
                }

                List<int> userDigits = new List<int>()
                {
                    userInput / 100 % 10,
                    userInput / 10 % 10,
                    userInput % 10
                };

                // 입력값 검증
                CompareDigits(Quest, userDigits, out strike, out ball);

                WriteLine($"\n{answer} : {strike} Strike, {ball} Ball");

            } while (strike < 3);

            WriteLine("\nStrike Out~!!! Game Over.");
        }

        public static int GetQuestNumber(List<int> questList)
        {
            Random random = new Random();

            int num = random.Next(0, 9);

            if (questList.Count == 0)
            {
                return num;
            }

            if (questList.Contains(num) == false)
            {
                return num;
            }

            return GetQuestNumber(questList);
        }

        // 숫자를 비교하여 스트라이크와 볼을 계산하는 메서드
        /*
         * answerDigits: 정답 숫자를 담고 있는 배열
         * userInput: 사용자가 입력한 숫자
         * strike: 스트라이크의 개수 (출력 파라미터)
         * ball: 볼의 개수 (출력 파라미터)
         */
        public static void CompareDigits(List<int> answerDigits, List<int> userInput, out int strike, out int ball)
        {
            // 스트라이크와 볼 초기화
            strike = 0;
            ball = 0;



            // 스트라이크와 볼 계산
            for (int i = 0; i < userDigits.Count && i < answerDigits.Count; i++)
            {
                // 입력된 숫자가 정답에 존재하는지 확인
                // Find 메서드를 사용하여 입력된 숫자의 인덱스를 찾음
                // 만약 존재하지 않으면 -1을 반환
                // Find 메서드를 사용하여 입력된 숫자의 인덱스를 찾음
                int result = answerDigits.IndexOf(userDigits[i]);

                if (result == -1)
                {
                    // 입력된 숫자가 정답에 존재하지 않으면 continue
                    continue;
                }

                // 같은 자리의 숫자가 일치하면 스트라이크 증가
                if ( result == i )
                {                     
                    strike++;
                    continue;
                }
                // 다른 자리의 숫자가 정답에 존재하면 볼 증가
                {   
                    ball++; 
                }
            }
        }
    }
}

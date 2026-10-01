using System.Windows.Forms;

namespace lab2_TPO_B
{
    public partial class Form1 : Form
    {
        // Таймер для інкрементування аргументу функції
        private System.Windows.Forms.Timer timer;

        // Поток для обчислення функції
        private System.Threading.Thread calcThread;

        // Параметри обчислення
        private double minX;
        private double maxX;
        private double step;

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(txtMinX.Text, out minX))
                {
                    lblStatus.Text = "Помилка: неправильно введено мінімальне значення X";
                    lblStatus.ForeColor = Color.Red;
                    return;
                }

                if (!double.TryParse(txtMaxX.Text, out maxX))
                {
                    lblStatus.Text = "Помилка: неправильно введено максимальне значення X";
                    lblStatus.ForeColor = Color.Red;
                    return;
                }

                if (!double.TryParse(txtStep.Text, out step))
                {
                    lblStatus.Text = "Помилка: неправильно введено крок";
                    lblStatus.ForeColor = Color.Red;
                    return;
                }

                if (!int.TryParse(txtInterval.Text, out int interval))
                {
                    lblStatus.Text = "Помилка: неправильно введено інтервал таймера";
                    lblStatus.ForeColor = Color.Red;
                    return;
                }

                if (minX >= maxX)
                {
                    lblStatus.Text = "Помилка: мінімальне значення X має бути менше за максимальне";
                    lblStatus.ForeColor = Color.Red;
                    return;
                }

                if (step <= 0)
                {
                    lblStatus.Text = "Помилка: крок має бути позитивним числом";
                    lblStatus.ForeColor = Color.Red;
                    return;
                }

                if (interval <= 0)
                {
                    lblStatus.Text = "Помилка: інтервал таймера має бути позитивним числом";
                    lblStatus.ForeColor = Color.Red;
                    return;
                }

                dgvResults.Rows.Clear();
                nudArgument.Value = (decimal)minX;
                timer.Interval = interval;
                timer.Start();

                lblStatus.Text = "Обчислення розпочато...";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Непередбачена помилка: {ex.Message}";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            lblStatus.Text = "Обчислення зупинено";
            lblStatus.ForeColor = Color.Orange;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            dgvResults.Rows.Clear();
            lblStatus.Text = "Таблиця очищена";
            lblStatus.ForeColor = Color.Blue;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            double currentX = (double)nudArgument.Value;

            if (currentX > maxX)
            {
                timer.Stop();
                lblStatus.Text = $"Обчислення завершено: аргумент X вийшов за межу максимального значення ({maxX})";
                lblStatus.ForeColor = Color.DarkGreen;
                return;
            }

            // Дочекаємося завершення попереднього потоку
            if (calcThread != null && calcThread.IsAlive)
            {
                calcThread.Join(TimeSpan.FromSeconds(1));
            }

            // Створюємо потік для обчислення
            ThreadStart threadStart = () => CalculateAndAddResult(currentX);
            calcThread = new System.Threading.Thread(threadStart);
            calcThread.IsBackground = true;
            calcThread.Start();

            nudArgument.Value += (decimal)step;
        }

        // Обчислює значення функції в окремому потоці
        // Використовуємо Invoke для безпечного оновлення UI контролів з фонового потоку
        // WinForms контроли не є потокобезпечними, тому звертання з іншого потоку
        // повинно здійснюватися через Invoke, який маршалює виклик до потоку UI
        private void CalculateAndAddResult(double x)
        {
            try
            {
                double result = FunctionCalculator.Calculate(x);
                int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;

                this.Invoke(new Action(() =>
                {
                    dgvResults.Rows.Add(
                        x.ToString("F2"),
                        result.ToString("F6"),
                        threadId
                    );

                    lblStatus.Text = $"Останнє обчислення: x={x:F2}, f(x)={result:F6}";
                    lblStatus.ForeColor = Color.Green;
                }));
            }
            catch (FunctionArgumentException fex)
            {
                this.Invoke(new Action(() =>
                {
                    dgvResults.Rows.Add(
                        x.ToString("F2"),
                        "Помилка",
                        System.Threading.Thread.CurrentThread.ManagedThreadId
                    );

                    lblStatus.Text = $"Помилка при x={x:F2}: {fex.Message}";
                    lblStatus.ForeColor = Color.Red;
                }));
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    dgvResults.Rows.Add(
                        x.ToString("F2"),
                        "Невідома помилка",
                        System.Threading.Thread.CurrentThread.ManagedThreadId
                    );

                    lblStatus.Text = $"Непередбачена помилка при x={x:F2}: {ex.Message}";
                    lblStatus.ForeColor = Color.Red;
                }));
            }
        }
    }
}

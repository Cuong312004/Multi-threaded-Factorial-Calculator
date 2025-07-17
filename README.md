# Multi-threaded-Factorial-Calculator

A Windows Forms application that calculates large factorials using multi-threading and visualizes execution time across different thread counts.

## 📌 Features

- Compute large factorials (e.g., 10000!) using configurable number of threads
- Parallel execution with task splitting to improve performance
- Execution time measured and visualized with **LiveCharts**
- Automatic result caching to optimize repeated calculations
- Simple, intuitive user interface built with **WinForms**
- Real-time updates to a **DataGridView** and performance **chart**

## 🛠️ Technologies Used

- **C#**, **.NET Framework**
- **WinForms** for UI
- **LiveCharts** for charting and performance visualization
- **BigInteger** for high-precision factorial computation
- **Multi-threading** (`Task.Run`, `Parallel`, async/await)


## 🔄 How It Works

1. User inputs a list of numbers and desired thread counts
2. For each number-thread pair:
   - Factorial is computed in parallel (divided into thread chunks)
   - Result and execution time are shown in the table
3. Execution time across thread counts is plotted on a line chart

## 📂 Folder Structure
```
Multi-threaded-Factorial-Calculator/
├── Form1.cs
├── Program.cs
├── Data.cs
├── Form1.Designer.cs
├── README.md
└── ...
```

## 🚀 Getting Started

### Prerequisites

- Visual Studio (recommended)
- .NET Framework (4.7.2 or higher)
- NuGet packages:
  - `LiveCharts.WinForms`
  - `LiveCharts.Wpf`

### Run the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/Cuong312004/Multi-threaded-Factorial-Calculator.git
   ```
2. Open the .sln file in Visual Studio

3. Restore NuGet packages if needed

4. Build and Run (F5)

##✅ Future Improvements
- Add option to save/export results
- Add support for cancellation during long computations
- Improve UI responsiveness

## 🖼️ Application Interface & Performance Chart

![Screenshot](https://github.com/Cuong312004/Multi-threaded-Factorial-Calculator/blob/main/image/1.png)

- The line chart displays execution time (in milliseconds) for computing 10! using various thread counts (1, 5, 10, 50, 100, 500).

- As shown, execution time initially decreases as threads increase, demonstrating parallel efficiency.

- However, at higher thread counts (e.g., 500), time increases slightly due to threading overhead, especially for small input sizes.

- The data table presents detailed results for each input:

    - Number: value to compute factorial of

    - Threads: number of threads used

    - Result: computed factorial

    - Time (ms): execution time for that configuration

✅ This visualization confirms that while multithreading improves performance, there is a practical limit where additional threads may cause overhead.

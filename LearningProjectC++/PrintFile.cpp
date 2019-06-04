#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

class PrintFile
{
	// 13.1
public:
	PrintFile()
	{ }

	static vector<string> PrintLast(string fileName, int k)
	{
		ifstream inFile;
		inFile.open(fileName);
		if (!inFile)
		{
			cerr << "Unable to open file " << fileName;
			exit(1);
		}

		vector<string> lastLines(k);
		int oldLine = 0;
		string line;
		while (inFile >> line)
		{
			lastLines[oldLine] = line;
			oldLine++;
			if (oldLine >= k)
				oldLine = 0;
			
		}

		for (int i = 0; i < lastLines.size(); i++)
		{
			cout << lastLines[(i + oldLine) % k] << "\n";
		}

		return lastLines;
	}

	static void RunPrintFile()
	{
		vector<string> lastLines = PrintFile::PrintLast("13-1.txt", 10);
	}
};
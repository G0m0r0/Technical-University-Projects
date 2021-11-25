#include <iostream>
#include <string>
#include <list>
#include <iterator>
#include <vector>
#include <fstream>
#include <sstream>
using namespace std;

class IAnimal {
	virtual string MakeSound() = 0;
	virtual string Sleep() = 0;
	virtual string Eat() = 0;
};

class Animal : public IAnimal {

private:
	string name;
	int age;

protected: int hunger;

public: Animal(string n, int a) {
	name = n;
	SetAge(a);
	hunger = 50;
};

protected: string Feed(int amount) {
	string message = "";
	if (hunger - amount < 0)
	{
		hunger = 0;
		message = "Animal can not eat so much food!";
	}
	else
	{
		hunger -= amount;
		message = "Animal was fed with " + to_string(amount) + " packs of food. Current hunger is " + to_string(hunger);
	};

	return message;
};

public: string IsAnimalHungry() {
	if (hunger > 100) {
		return name + " is very hungry!";
	}
	else if (hunger > 50) {
		return name + " should be fed soon!";
	}

	return name + " is not hungry.";
};

public:
	int GetAge() {
		return age;
	};

	string GetName() {
		return name;
	};

	int GetHunger() {
		return hunger;
	};
	string Print() {
		string message = GetName() + " is born " + to_string(CalculateBornYear()) + " he is " + to_string(age)
			+ " years old. " + IsAnimalHungry() + "\n"
			+ "It makes, " + MakeSound() + "\n"
			+ "Usually " + Sleep() + "\n";
		return message;
	}

private: void SetAge(int a) {
	if (a < 0 || a > 300) {
		throw exception("Invalid age! Age can not be less than 0 or more than 300!");
	}
	age = a;
};

public: int CalculateBornYear() {
	time_t current_time = time(NULL);
	int year = 1970 + current_time / 31537970;

	int yearBorn = year - age;

	return yearBorn;
};
public:
	string MakeSound() override { return "default"; };
	string Sleep() override { return NULL; };
	string Eat() override { return NULL; };
};

class Cat :public Animal {

public: Cat(string n, int a) : Animal(n, a)
{
};

public:
	string MakeSound()override {
		hunger -= 10;

		return "cat sound, Meow Meow";
	}

	string Sleep()override {
		string message = "";
		if (GetHunger() > 50)
		{
			message = GetName() + "is sleeping very lightly!";
		}
		else
		{
			message = GetName() + " is sleeping very deep!";
		}
		return message;
	}

	string Eat()override {
		int catFood = 10;

		string message = Feed(catFood);

		return message;
	}

};

class Dog :public Animal {
private: int size;
private: bool isDogBig;

public: Dog(string n, int a, int s) : Animal(n, a)
{
	SetSize(s);
};

private: void SetSize(int s) {
	if (s >= 50) {
		isDogBig = true;
	}
	else if (s > 0)
	{
		isDogBig = false;
	}

	size = s;
};

public: int GetSize() {
	return size;
}

public:
	string MakeSound()override {
		hunger -= 20;

		if (isDogBig) {
			return "big dog sound, Bauu Bauu";
		}

		return "small dog sound, Bauuu";
	}

	string Sleep()override {
		string message = "Dogs always sleep lightly they have to alert threat!";

		return message;
	}

	string Eat()override {
		int dogFood = 30;

		if (GetHunger() == 50 && isDogBig) {
			dogFood = 50;
		}

		string message = Feed(dogFood);

		return message;
	}

};

class PetManager {
public:
	vector< unique_ptr<Animal>> animals;
	PetManager() {
		animals = vector< unique_ptr<Animal>>();
	};

	void CreatePet(string type) {
		cout << "Name: ";
		string name = "";
		cin >> name;

		cout << "Age: ";
		int age = 0;
		cin >> age;

		if (type == "dog") {
			cout << "Size in %: ";
			int size = 0;
			cin >> size;

			//Dog dog = Dog(name, age, size);
			animals.push_back(make_unique<Dog>(name, age, size));
		}
		else if (type == "cat") {
			animals.push_back(make_unique<Cat>(name, age));
		}

		cout << endl;
	}

	void FeedAllAnimals() {
		for (int i = 0; i < animals.size(); i++) {
			cout << animals.at(i).get()->Eat() << endl;
		}
	}

	void SleepAll() {
		for (int i = 0; i < animals.size(); i++) {
			cout << animals.at(i).get()->Sleep() << endl;
		}
	}

	void MakeAllAnimalsCreateSound() {
		for (int i = 0; i < animals.size(); i++) {
			cout << animals.at(i).get()->MakeSound() << endl;
		}
	}

	void Print() {
		for (int i = 0; i < animals.size(); i++) {
			cout << animals.at(i).get()->Print() << endl;
		}
	}

	void SaveData()
	{
		ofstream file;
		file.open("Animals.txt");

		for (auto i = 0; i < animals.size(); i++) {
			file << animals.at(i).get()->Print() << endl;
		}

		file.close();
		cout << "Successfully saved to file!" << endl;
	};
};

int main()
{
	cout << "Enter number of animals to create: ";
	int count = 0;
	cin >> count;

	PetManager animals = PetManager();
	for (auto i = 0; i < count; i++)
	{
		cout << "Create cat or dog: ";
		string type = "";
		cin >> type;
		animals.CreatePet(type);
	}

	cout << endl;
	animals.MakeAllAnimalsCreateSound();
	cout << endl;
	animals.SleepAll();
	cout << endl;
	animals.FeedAllAnimals();
	cout << endl;
	animals.Print();
	cout << endl;
	animals.SaveData();
}

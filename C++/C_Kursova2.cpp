#include <iostream>
using namespace std;
#include <list>
#include <iterator>
#include <algorithm>
#include <iostream>
#include <string>

class Interface {
public:
	virtual void show() = 0;
	virtual int get_typicalParameter() = 0;
};
class vehicle : public Interface {
public:
	int wheels;
	int passengers;
	vehicle(int w, int p)
	{
		wheels = w;
		passengers = p;
	};
	vehicle()
	{
	};
	int get_wheels() { return wheels; }
	void set_wheels(int num) { wheels = num; }
	int get_pass() { return passengers; }
	void set_pass(int num) { passengers = num; }
	int get_typicalParameter()override { return NULL; };
	void show()override
	{
		cout << "wheels: " << get_wheels() << "\n";
		cout << "passengers: " << get_pass() << "\n";
	};
};

class truck : public vehicle {
public:
	int cargo;
	char vt = 't';
	truck(int w, int p, int c)
	{
		wheels = w;
		passengers = p;
		cargo = c;
	};
	truck()
	{
	};
	char get_vt() { return vt; }
	int get_typicalParameter() override { return cargo; }
	void set_cargo(int size) { cargo = size; }
	void show()override
	{
		cout << "Truck:" << endl;
		cout << "wheels: " << get_wheels() << "\n";
		cout << "passengers: " << get_pass() << "\n";
		cout << "cargo capacity in cubic feet: " << get_typicalParameter() << "\n";
		cout << "..............................................." << endl;
	};
};

class automobile : public vehicle {
public:
	int car_hp;
	char vt = 'a';
	automobile(int w, int p, int t)
	{
		wheels = w;
		passengers = p;
		car_hp = t;
	};
	automobile()
	{
	};
	char get_vt() { return vt; }
	int get_typicalParameter() override { return car_hp; }
	void set_hp(int t) { car_hp = t; }
	void show()override
	{
		cout << "Automobile:" << endl;
		cout << "wheels: " << get_wheels() << "\n";
		cout << "passengers: " << get_pass() << "\n";
		cout << "hp: " << get_typicalParameter() << endl;
		cout << "..............................................." << endl;
	};
};

class container {
public:
	list <vehicle> collection;
	void addVehicleTest(int wheels, int passengers, int typicalParameter, char type)
	{
		if (type == 't')
		{
			truck t(wheels, passengers, typicalParameter);
			collection.push_back(t);

		}
		else if (type == 'a')
		{
			automobile a(wheels, passengers, typicalParameter);
			collection.push_back(a);
		}
	};
	void addVehicle() {
		int a, b, c;
		string type;
		cout << "Enter the type of the vehicle (a for automobile, t for truck):";
		getline(cin, type);
		if (type == "a")
		{
			cout << "Enter a number of wheels:";
			cin >> a;
			cout << endl;
			cout << "Enter a number of passengers:";
			cin >> b;
			cout << endl;
			cout << "Enter the horse powers for the automobile:";
			cin >> c;
			cout << endl;
			automobile au(a, b, c);
			collection.push_back(au);
			cout << "Ready!" << endl;
		}
		else if (type == "t")
		{
			cout << "Enter a number of wheels:";
			cin >> a;
			cout << endl;
			cout << "Enter a number of passengers:";
			cin >> b;
			cout << endl;
			cout << "Enter the capacity of the cargo:";
			cin >> c;
			cout << endl;
			truck t(a, b, c);
			collection.push_back(t);
			cout << "Ready!" << endl;
		}
	};
	void showAllVehicles()
	{
		for (auto x : collection) {
			x.show();
		}
	};
};
int main()
{
	truck t1(18, 2, 3200);
	truck t2(6, 3, 1200);
	automobile c(4,6,120);
	container a;
	a.addVehicleTest(t1.get_wheels(), t1.get_pass(), t1.get_typicalParameter(), t1.get_vt());
	a.addVehicleTest(t2.get_wheels(), t2.get_pass(), t2.get_typicalParameter(), t2.get_vt());
	a.addVehicleTest(c.get_wheels(), c.get_pass(), c.get_typicalParameter(), c.get_vt());
	//a.addVehicle();
	a.showAllVehicles();
}

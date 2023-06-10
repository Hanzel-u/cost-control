import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:my_money/controllers/budget_controller.dart';
import 'package:my_money/controllers/home_controller.dart';

class Home extends StatefulWidget {
  const Home({super.key});

  @override
  State<Home> createState() => _HomeState();
}

class _HomeState extends State<Home> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      floatingActionButton: FloatingActionButton(
        onPressed: () => GoRouter.of(context).push('/expense'),
        foregroundColor: Colors.black,
        tooltip: "Agregar gasto",
        backgroundColor: Colors.greenAccent,
        child: const Icon(Icons.add),
      ),
      body: Column(
        children: [
          // Body
          Padding(
            padding: EdgeInsets.only(
              left: MediaQuery.of(context).size.width * 0.15,
              top: MediaQuery.of(context).size.height * 0.1,
              right: MediaQuery.of(context).size.width * 0.15,
            ),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Text("Widget de porcentaje en circulo"),
                SizedBox(height: 50),
                ElevatedButton(
                    onPressed: () => resetData(context),
                    child: const Text("Eliminar presupuesto y datos"),
                    style: ElevatedButton.styleFrom(foregroundColor: Colors.black, backgroundColor: Colors.redAccent)),
                Text("Presupuesto: ${moneyProvider.budget.toString()} \$", style: TextStyle(fontSize: 25)),
                Text("Balance: ${moneyProvider.balance.toString()} \$", style: TextStyle(fontSize: 25)),
                Text("Gastos: ${moneyProvider.expenses.toString()} \$", style: TextStyle(fontSize: 25)),
                SizedBox(height: 50),
                Text("Filtrar gastos por:"),
                SizedBox(height: 50),
                Container(
                  height: MediaQuery.of(context).size.height * 0.3,
                  width: double.infinity,
                  color: Colors.grey,
                  child: ListView.separated(
                    itemCount: moneyProvider.expensesList.length,
                    itemBuilder: (context, i) {
                      return Container(
                        color: Colors.white,
                        height: 150,
                        width: MediaQuery.of(context).size.width * 0.8,
                        child: Column(children: [
                          Text(moneyProvider.expensesList[i]['name']),
                          Text(moneyProvider.expensesList[i]['category']),
                          Text(moneyProvider.expensesList[i]['amount'].toString()),
                        ]),
                      );
                    },
                    separatorBuilder: (context, i) => Container(height: 10),
                  ),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}

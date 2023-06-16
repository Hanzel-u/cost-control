// un provider es una clase que nos permite compartir
// información entre widgets y acualizar de forma
// reactiva los widgets que esten escuchando los
// cambios de la información
import 'dart:math';

import 'package:flutter/foundation.dart';

class MoneyProvider with ChangeNotifier {
  int budget = 0;
  int balance = 0;
  int expenses = 0;
  List<String> categories = ["Ahorro", "Comida", "Casa", "Gastos", "Ocio", "Salud", "Suscripciones", "Otros"];
  List<Map<String, dynamic>> expensesList = [];

  void addExpense(Map<String, dynamic> expense) {
    print('LISTA: ${expensesList}');
    expensesList.add(expense);
    print('LISTA: ${expensesList}');
    expenses += expense['amount'] as int;
    balance -= expense['amount'] as int;
    notifyListeners();
  }

  void clear() {
    budget = 0;
    balance = 0;
    expenses = 0;
    expensesList = [];
    notifyListeners();
  }
}

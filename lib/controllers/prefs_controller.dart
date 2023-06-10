import 'package:flutter/foundation.dart';
import 'package:my_money/controllers/budget_controller.dart';
import 'package:shared_preferences/shared_preferences.dart';

saveValue(type, name, value) async {
  final prefs = await SharedPreferences.getInstance();
  if (type == 'int') {
    prefs.setInt(name, value);
  } else if (type == 'double') {
    prefs.setDouble(name, value);
  } else if (type == 'string') {
    prefs.setString(name, value);
  } else if (type == 'bool') {
    prefs.setBool(name, value);
  } else if (type == 'stringList') {
    prefs.setStringList(name, value);
  }
}

getValue(type, name) async {
  final prefs = await SharedPreferences.getInstance();
  if (type == 'int') {
    return prefs.getInt(name) ?? 0;
  } else if (type == 'double') {
    return prefs.getDouble(name) ?? 0.0;
  } else if (type == 'string') {
    return prefs.getString(name) ?? '';
  } else if (type == "bool") {
    return prefs.getBool(name) ?? false;
  } else if (type == 'stringList') {
    return prefs.getStringList(name) ?? [];
  }
}

cleanValues() async {
  final prefs = await SharedPreferences.getInstance();
  prefs.clear();
  moneyProvider.clear();
}

class Expense {
  late String name;
  late int amount;
  late String category;

  Expense({required name, required amount, required category}) {
    throw UnimplementedError();
  }

  factory Expense.fromJson(Map<String, dynamic> json) {
    String name = json['name'];
    int amount = json['amount'];
    String category = json['category'];

    return Expense(amount: amount, name: name, category: category);
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['amount'] = amount;
    data['name'] = name;
    data['category'] = category;
    return data;
  }

  @override
  String toString() {
    return '"info" : { "amount": $amount, "name": $name, "category": $category}';
  }
}

//me quede atorado aca
// Future<void> saveExpense(name, amount, category) async {
//   final expense = Expense(name: name, amount: amount, category: category);
//   final SharedPreferences prefs = await SharedPreferences.getInstance();
//   saveValue('stringList', name, value)
// }

import 'package:go_router/go_router.dart';
import 'package:my_money/controllers/budget_controller.dart';
import 'package:my_money/controllers/prefs_controller.dart';

Map<String, dynamic> expense = {};

selectCategory(category) {
  expense['category'] = category;
}

validateAmount(value) {
  if (value == null || value.isEmpty) {
    return "Ingresa una cantidad";
  }
  if (int.parse(value) > 0) {
    expense['amount'] = int.parse(value);
    return null;
  }
  return "Ingresa una cantidad mayor a 0";
}

validateName(value) {
  if (value == null || value.isEmpty) {
    return "Ingresa un nombre";
  }
  expense['name'] = value;
  return null;
}

setExpense(context, formKey) {
  if (formKey.currentState.validate()) {
    formKey.currentState.save();
    moneyProvider.addExpense(expense);
    saveValue('int', 'balance', moneyProvider.balance);
    saveValue('int', 'expense', moneyProvider.expenses);
    saveValue('stringList', 'expensesList', moneyProvider.expensesList);
    GoRouter.of(context).pushReplacement('/home');
  }
}

validatorCategory(value) {
  if (value == null || value.isEmpty) {
    return "Selecciona una categoria";
  }
  expense['category'] = value;
  return null;
}

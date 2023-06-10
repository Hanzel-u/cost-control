import 'package:my_money/controllers/prefs_controller.dart';
import 'package:my_money/providers/my_money_provider.dart';
import 'package:go_router/go_router.dart';

MoneyProvider moneyProvider = MoneyProvider();

budgetValidator(value) {
  if (value.isEmpty) {
    return 'Porfavor ingrese un valor';
  } else {
    value = int.parse(value);
    if (value <= 0) {
      return 'Porfavor ingrese un valor positivo mayor a 0';
    }
    moneyProvider.budget = value;
  }
}

budgetSet(context, formKey) async {
  if (formKey.currentState.validate()) {
    formKey.currentState.save();
    saveValue('int', 'budget', moneyProvider.budget);
    moneyProvider.balance = moneyProvider.budget;
    saveValue('int', 'balance', moneyProvider.balance);
    saveValue('bool', 'hasData', true);
    GoRouter.of(context).pushReplacement('/home');
  }
}

loadBudgetData(context) async {
  if (await getValue('bool', 'hasData') == false) {
    return;
  }
  moneyProvider.budget = await getValue('int', 'budget');
  moneyProvider.balance = await getValue('int', 'balance');
  GoRouter.of(context).pushReplacement('/home');
}

// Copyright 2020 The Flutter team. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:my_money/controllers/budget_controller.dart';
import 'package:my_money/controllers/expense_controller.dart';

class Expense extends StatefulWidget {
  const Expense({super.key});

  @override
  State<Expense> createState() => _ExpenseState();
}

class _ExpenseState extends State<Expense> {
  GlobalKey<FormState> formKey = GlobalKey<FormState>();
  TextEditingController nameController = TextEditingController();
  TextEditingController amountController = TextEditingController();
  TextEditingController categoryController = TextEditingController();

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.lightGreenAccent,
        title: const Text('Agregar gasto'),
        leading: IconButton(
          icon: const Icon(Icons.arrow_back),
          onPressed: () => GoRouter.of(context).pushReplacement('/home'),
        ),
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            // Body
            Form(
              key: formKey,
              child: Padding(
                padding:
                    EdgeInsets.symmetric(horizontal: MediaQuery.of(context).size.width * 0.15, vertical: MediaQuery.of(context).size.height * 0.1),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    TextFormField(
                      decoration: const InputDecoration(
                        enabledBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color.fromARGB(255, 196, 196, 196),
                          ),
                        ),
                        focusedBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color.fromARGB(255, 196, 196, 196),
                          ),
                        ),
                        focusedErrorBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color.fromARGB(255, 207, 13, 13),
                          ),
                        ),
                        label: Text("Nombre de gasto"),
                        contentPadding: EdgeInsets.symmetric(vertical: 10, horizontal: 10),
                      ),
                      autovalidateMode: AutovalidateMode.onUserInteraction,
                      keyboardType: TextInputType.text,
                      controller: nameController,
                      validator: (value) => validateName(value),
                    ),
                    const SizedBox(
                      height: 24,
                    ),
                    TextFormField(
                      decoration: const InputDecoration(
                        enabledBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color.fromARGB(255, 196, 196, 196),
                          ),
                        ),
                        focusedBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color.fromARGB(255, 196, 196, 196),
                          ),
                        ),
                        focusedErrorBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color.fromARGB(255, 207, 13, 13),
                          ),
                        ),
                        label: Text("Cantidad"),
                        contentPadding: EdgeInsets.symmetric(vertical: 10, horizontal: 10),
                      ),
                      autovalidateMode: AutovalidateMode.onUserInteraction,
                      keyboardType: TextInputType.number,
                      controller: amountController,
                      validator: (value) => validateAmount(value),
                    ),
                    const SizedBox(
                      height: 24,
                    ),
                    DropdownButtonFormField(
                      autovalidateMode: AutovalidateMode.onUserInteraction,
                      decoration: const InputDecoration(
                        enabledBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color.fromARGB(255, 196, 196, 196),
                          ),
                        ),
                        focusedBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color.fromARGB(255, 196, 196, 196),
                          ),
                        ),
                        focusedErrorBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color.fromARGB(255, 207, 13, 13),
                          ),
                        ),
                        label: Text("Categoria"),
                        contentPadding: EdgeInsets.symmetric(vertical: 10, horizontal: 10),
                      ),
                      items: moneyProvider.categories.map((itemone) {
                        return DropdownMenuItem(value: itemone, child: Text(itemone));
                      }).toList(),
                      validator: (value) => validatorCategory(value),
                      onChanged: (value) {},
                    ),
                    // DropdownMenu(
                    //   label: const Text("Categoria"),
                    //   controller: categoryController,
                    //   initialSelection: "otros",
                    //   onSelected: (value) => selectCategory(value),
                    //   dropdownMenuEntries: const <DropdownMenuEntry<String>>[
                    //     DropdownMenuEntry(value: "Ahorro", label: "Ahorro"),
                    //     DropdownMenuEntry(value: "comida", label: "comida"),
                    //     DropdownMenuEntry(value: "transporte", label: "transporte"),
                    //     DropdownMenuEntry(value: "salud", label: "salud"),
                    //     DropdownMenuEntry(value: "entretenimiento", label: "entretenimiento"),
                    //     DropdownMenuEntry(value: "educacion", label: "educacion"),
                    //     DropdownMenuEntry(value: "otros", label: "otros"),
                    //   ],
                    // ),
                    const SizedBox(
                      height: 24,
                    ),
                    ElevatedButton(
                      onPressed: () {
                        setExpense(context, formKey);
                      },
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.green,
                        foregroundColor: Colors.white,
                      ),
                      child: const Text('Confirmar'),
                    )
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

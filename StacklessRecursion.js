function stacklessRecursion(func) {

    return function(...args) {
        let stack = [func(...args)];
        let ret = undefined;
        while (stack.length > 0) {
            let iterationResult = stack[stack.length - 1].next(ret);
            if (iterationResult.done) {
                ret = iterationResult.value;
                stack.pop();
            } else {
                stack.push(func(...iterationResult.value))
            }
        }
        return ret;
    };
}




function stacklessRecursion_UsageExample() {

    const factorial = stacklessRecursion(function*(i) {
        return i <= 1 ? 1 : i * (yield [i - 1]);
    });

    const fibonacci = stacklessRecursion(function*(i) {
        return i <= 1 ? i : (yield [i - 1]) + (yield [i - 2]);
    })



    console.log("Factorial:");
    for (let t = 0; t < 100; ++t)
        console.log(factorial(t));

    console.log(factorial(100000));
    console.log("Completed successfully without a crash!");

    console.log("\nFibonacci:");
    for (let t = 0; t < 25; ++t)
        console.log(fibonacci(t));
}

stacklessRecursion_UsageExample();
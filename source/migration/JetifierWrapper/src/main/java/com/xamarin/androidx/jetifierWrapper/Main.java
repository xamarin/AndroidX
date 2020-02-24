package com.xamarin.androidx.jetifierWrapper;

import com.android.tools.build.jetifier.core.config.*;
import com.android.tools.build.jetifier.core.pom.DependencyVersions;
import com.android.tools.build.jetifier.core.utils.Log;
import com.android.tools.build.jetifier.processor.FileMapping;
import com.android.tools.build.jetifier.processor.Processor;
import com.android.tools.build.jetifier.processor.archive.*;
import com.android.tools.build.jetifier.processor.transform.TransformationContext;
import com.android.tools.build.jetifier.processor.transform.proguard.ProGuardTransformer;

import org.apache.commons.cli.*;

import java.io.File;
import java.io.IOException;
import java.io.FileNotFoundException;
import java.nio.file.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;
import java.util.List;
import java.util.concurrent.*;

import static com.android.tools.build.jetifier.standalone.Main.Companion;

public class Main {
    private static final int MAX_THREADS = 10;
    private static final Options OPTIONS;
    private static Option INPUT_OPTION;
    private static Option OUTPUT_OPTION;
    private static Option CONFIG_OPTION;
    private static Option LOG_LEVEL_OPTION;
    private static Option REVERSED_OPTION;
    private static Option STRICT_OPTION;
    private static Option REBUILD_TOP_OF_TREE_OPTION;
    private static Option STRIP_SIGNATURES_OPTION;
    private static Option PRO_GUARD_OPTION;
    private static Option INTERMEDIATE_OPTION;
    private static Option PARALLEL_OPTION;
    private static Option HELP_OPTION;

    private static boolean IS_REVERSED;
    private static boolean IS_STRICT;
    private static boolean SHOULD_REBUILD_TOP_OF_TREE;
    private static boolean SHOULD_STRIP_SIGNATURES;
    private static boolean IS_PRO_GUARD;
    private static boolean HAS_INTERMEDIATE;
    private static boolean HAS_LOG_LEVEL;
    private static boolean HAS_CONFIG;
    private static boolean IS_PARALLEL;
    private static boolean HAS_INPUTS;
    private static boolean HAS_OUTPUTS;

    private static CommandLine COMMAND_LINE;

    private static List<String> INPUT_VALUES;
    private static List<String> OUTPUT_VALUES;

    private static Config JETIFIER_CONFIG;
    private static Processor JETIFIER_PROCESSOR;
    private static ProGuardTransformer PRO_GUARD_TRANSFORMER;

    private static long START_TIME;
    private static long END_TIME;

    public static void main(String[] args) {
        // create options
        createOptionsFromJetifier();
        INPUT_OPTION = OPTIONS.getOption("i");
        OUTPUT_OPTION = OPTIONS.getOption("o");
        CONFIG_OPTION = OPTIONS.getOption("c");
        LOG_LEVEL_OPTION = OPTIONS.getOption("l");
        REVERSED_OPTION = OPTIONS.getOption("r");
        STRICT_OPTION = OPTIONS.getOption("s");
        REBUILD_TOP_OF_TREE_OPTION = OPTIONS.getOption("rebuildTopOfTree");
        STRIP_SIGNATURES_OPTION = OPTIONS.getOption("stripSignatures");
        PRO_GUARD_OPTION = OPTIONS.getOption("isProGuard");
        INTERMEDIATE_OPTION = OPTIONS.getOption("intermediate");
        PARALLEL_OPTION = OPTIONS.getOption("p");
        HELP_OPTION = OPTIONS.getOption("h");

        // parse options
        try {
            COMMAND_LINE = new DefaultParser().parse(OPTIONS, args);
        } catch (ParseException e) {
            Log.INSTANCE.e("Main", e.getMessage());
            printHelp();
            System.exit(1);
            return;
        }

        if (COMMAND_LINE.hasOption(HELP_OPTION.getOpt())) {
            printHelp();
            System.exit(0);
            return;
        }

        HAS_CONFIG = COMMAND_LINE.hasOption(CONFIG_OPTION.getOpt());
        HAS_LOG_LEVEL = COMMAND_LINE.hasOption(LOG_LEVEL_OPTION.getOpt());
        IS_REVERSED = COMMAND_LINE.hasOption(REVERSED_OPTION.getOpt());
        IS_STRICT = COMMAND_LINE.hasOption(STRICT_OPTION.getOpt());
        SHOULD_REBUILD_TOP_OF_TREE = COMMAND_LINE.hasOption(REBUILD_TOP_OF_TREE_OPTION.getOpt());
        SHOULD_STRIP_SIGNATURES = COMMAND_LINE.hasOption(STRIP_SIGNATURES_OPTION.getOpt());
        IS_PRO_GUARD = COMMAND_LINE.hasOption(PRO_GUARD_OPTION.getOpt());
        HAS_INTERMEDIATE = COMMAND_LINE.hasOption(INTERMEDIATE_OPTION.getOpt());
        IS_PARALLEL = COMMAND_LINE.hasOption(PARALLEL_OPTION.getOpt());
        HAS_INPUTS = COMMAND_LINE.hasOption(INPUT_OPTION.getOpt());
        HAS_OUTPUTS = COMMAND_LINE.hasOption(OUTPUT_OPTION.getOpt());

        INPUT_VALUES = new ArrayList<>();
        OUTPUT_VALUES = new ArrayList<>();

        if (HAS_INPUTS || HAS_OUTPUTS) {
            String[] inputs = COMMAND_LINE.getOptionValues(INPUT_OPTION.getOpt());
            String[] outputs = COMMAND_LINE.getOptionValues(OUTPUT_OPTION.getOpt());
    
            if (HAS_INPUTS != HAS_OUTPUTS || inputs.length != outputs.length) {
                Log.INSTANCE.e("Main", "The length of inputs and outputs must be the same.");
                printHelp();
                System.exit(1);
                return;
            }

            Collections.addAll(INPUT_VALUES, inputs);
            Collections.addAll(OUTPUT_VALUES, outputs);
        }

        if (HAS_INTERMEDIATE) {
            String intermediatePath = COMMAND_LINE.getOptionValue(INTERMEDIATE_OPTION.getOpt());
            try {
                loadIntermediateFile(intermediatePath, INPUT_VALUES, OUTPUT_VALUES);
            } catch (FileNotFoundException e) {
                e.printStackTrace();
                System.exit(1);
            }
        }

        JETIFIER_CONFIG = ConfigParser.INSTANCE.loadDefaultConfig();

        try {
            executeJetifier();
        } catch (IOException e) {
            e.printStackTrace();
            System.exit(1);
        }

        END_TIME = System.currentTimeMillis();
        double duration = (END_TIME - START_TIME) / 1000.0;

        Log.INSTANCE.i("Main","The jetifier process took: " + duration + " seconds");
    }

    private static void loadIntermediateFile(String intermediatePath, List<String> inputs, List<String> outputs) throws FileNotFoundException {
        Scanner sc = new Scanner(new File(intermediatePath));
        List<String> lines = new ArrayList<String>();
        while (sc.hasNextLine()) {
            String line = sc.nextLine();
            if (line.isEmpty())
                continue;
            String[] parts = line.split(";");
            inputs.add(parts[0]);
            if (parts.length > 0)
                outputs.add(parts[1]);
            else
                outputs.add(parts[0]);
        }
    }

    private static void createOptionsFromJetifier() {
        for (Option option : Companion.getOPTIONS().getOptions()) {
            String description = option.getDescription();
            boolean hasArguments = option.hasArgs();
            boolean isRequired = option.isRequired();

            switch (option.getOpt()) {
                case "i":
                case "o":
                    description += ". Can be used multiple times";
                    hasArguments = true;
                    isRequired = false;
                    break;
                case "c":
                case "l":
                    hasArguments = true;
                default:
                    break;
            }

            OPTIONS.addOption(createOption(option.getOpt(), option.getLongOpt(), description, hasArguments, isRequired));
        }

        OPTIONS.addOption(createOption("isProGuard", "isProGuard", "Files should be processed as ProGuard files.", false, false));
        OPTIONS.addOption(createOption("intermediate", "intermediate", "Files should be read from the intermediate file.", true, false));
        OPTIONS.addOption(createOption("p", "parallel", "Jetifiy the aar/zip files in parallel.", false, false));
        OPTIONS.addOption(createOption("h", "help", "Show this message.", false, false));
    }

    private static final Option createOption(final String argumentName, final String argumentNameLong, final String description, final boolean hasArguments, final boolean isRequired) {
        final Option op = new Option(argumentName, argumentNameLong, hasArguments, description);
        op.setRequired(isRequired);
        return op;
    }

    private static void printHelp() {
        new HelpFormatter().printHelp("Jetifier Wrapper", OPTIONS);
    }

    private static ProGuardTransformer createProGuardTransformer() {
        DependencyVersions versionsMap = DependencyVersions.Companion.parseFromVersionSetTypeId(JETIFIER_CONFIG.getVersionsMap(), null);
        TransformationContext transformationContext = new TransformationContext(JETIFIER_CONFIG, SHOULD_REBUILD_TOP_OF_TREE, IS_REVERSED, !IS_STRICT, false, versionsMap);
        return new ProGuardTransformer (transformationContext);
    }

    private static void executeJetifier() throws IOException {
        int inputsLength = INPUT_VALUES.size();
        int threads = (inputsLength > MAX_THREADS) ? MAX_THREADS : inputsLength;
        int numberOfThreads = IS_PARALLEL ? threads : 1;

        Log.INSTANCE.i("Main", "Executing jetifier tool in " + (IS_PARALLEL ? "parallel" : "serial") + "way.");

        ExecutorService executor = Executors.newFixedThreadPool(numberOfThreads);
        List<Future<JetifierData>> jetifierWorks = new ArrayList<>();

        if (IS_PRO_GUARD) {
            PRO_GUARD_TRANSFORMER = createProGuardTransformer();
        } else {
            JETIFIER_PROCESSOR = Processor.Companion.createProcessor3(JETIFIER_CONFIG, IS_REVERSED, SHOULD_REBUILD_TOP_OF_TREE, !IS_STRICT, false, SHOULD_STRIP_SIGNATURES, null);
        }

        for (int i = 0; i < inputsLength; i++) {
            String inputFile = INPUT_VALUES.get(i);
            String outputFile = OUTPUT_VALUES.get(i);
            FileMapping fileMapping = new FileMapping(new File(inputFile), new File(outputFile));

            JetifierData jetifierData = null;
            if (IS_PRO_GUARD) {
                ArchiveItem archiveItem = getArchiveFile(inputFile);
                jetifierData = new JetifierData(fileMapping, archiveItem, PRO_GUARD_TRANSFORMER);
            } else {
                String from = inputFile.toLowerCase();
                if (from.endsWith(".aar") || from.endsWith(".zip") || from.endsWith(".jar")) {
                    String[] arguments = getArgumentsForJetifier(inputFile, outputFile);
                    jetifierData = new JetifierData(fileMapping, arguments);
                } else {
                    ArchiveItem archiveItem = getArchiveFile(inputFile);
                    jetifierData = new JetifierData(fileMapping, archiveItem, JETIFIER_PROCESSOR);
                }
            }

            Log.INSTANCE.v("Main", "Jetifiying " + inputFile + " file into " + outputFile + " file.");

            Callable<JetifierData> jetifier = new JetifierCallable(jetifierData);
            Future<JetifierData> jetifierWork = executor.submit(jetifier);
            jetifierWorks.add(jetifierWork);
        }

        for (Future<JetifierData> jetifierWork : jetifierWorks) {
            try {
                JetifierData jetifierData = jetifierWork.get();
                Log.INSTANCE.v("Main", "File " + jetifierData.getFileMapping().getFrom().getAbsolutePath() + " jetified into " + jetifierData.getFileMapping().getTo().getAbsolutePath() + " file.");
            } catch (InterruptedException e) {
                Log.INSTANCE.e("Main", e.getMessage());
            } catch (ExecutionException e) {
                Log.INSTANCE.e("Main", e.getMessage());
            }
        }

        executor.shutdown();
    }

    private static String[] getArgumentsForJetifier(String inputFile, String outputFile) {
        ArrayList<String> argumentsList = new ArrayList<>();

        if (HAS_CONFIG) {
            argumentsList.add("-" + CONFIG_OPTION.getOpt());
            argumentsList.add(COMMAND_LINE.getOptionValue(CONFIG_OPTION.getOpt()));
        }

        if (HAS_LOG_LEVEL) {
            String logLevel = COMMAND_LINE.getOptionValue(LOG_LEVEL_OPTION.getOpt());
            Log.INSTANCE.setLevel(logLevel);
            argumentsList.add("-" + LOG_LEVEL_OPTION.getOpt());
            argumentsList.add(logLevel);
        }

        if (IS_REVERSED)
            argumentsList.add("-" + REVERSED_OPTION.getOpt());

        if (IS_STRICT)
            argumentsList.add("-" + STRICT_OPTION.getOpt());

        if (SHOULD_REBUILD_TOP_OF_TREE)
            argumentsList.add("-" + REBUILD_TOP_OF_TREE_OPTION.getOpt());

        if (SHOULD_STRIP_SIGNATURES)
            argumentsList.add("-" + STRIP_SIGNATURES_OPTION.getOpt());

        argumentsList.add("-i");
        argumentsList.add(inputFile);

        argumentsList.add("-o");
        argumentsList.add(outputFile);

        String[] arguments = new String[argumentsList.size()];
        return argumentsList.toArray(arguments);
    }

    public static ArchiveFile getArchiveFile(String inputFilename) throws IOException {
        Path path = Paths.get(inputFilename);
        byte[] fileContent = Files.readAllBytes(path);
        return new ArchiveFile(path, fileContent);
    }

    static {
        START_TIME = System.currentTimeMillis();
        OPTIONS = new Options();
    }
}

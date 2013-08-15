$LOAD_PATH.unshift File.expand_path("./../../../BuildAndDeploy/BuildTools")
$LOAD_PATH.unshift File.expand_path("./../../../BuildAndDeploy/BuildTools/Jenkins")
$LOAD_PATH.unshift File.expand_path("./../../../BuildAndDeploy/TestTools")
$LOAD_PATH.unshift File.expand_path("\\\\cr-public-a01r\\DevToolsRepository\\BuildAndDeploy\\BuildTools")
$LOAD_PATH.unshift File.expand_path("\\\\cr-public-a01r\\DevToolsRepository\\BuildAndDeploy\\BuildTools\\Jenkins")
$LOAD_PATH.unshift File.expand_path("\\\\cr-public-a01r\\DevToolsRepository\\BuildAndDeploy\\TestTools")
puts $LOAD_PATH

require 'Package'
require 'Solution'
require 'Project'
require 'ChangeSet'

taxBuilderProjectNames = %w[
  FormImage.BusinessLogic
  TaxBuilder.ITaxBuilderData
  ]

taxBuilderSolution = Solution.new("TaxBuilder", Array.new(), Array.new())
  
taxBuilderSolution.files << SolutionFile.new("Rakefile",  Array.new())

taxBuilderProjectNames.each() do |name|
  taxBuilderSolution.projects << Project.new(name, Array.new(), true)
end

runtimeWebServiceSolutions = Array.new()
runtimeWebServiceSolutions << taxBuilderSolution

runtimeWebService = Package.new("RuntimeWebService", runtimeWebServiceSolutions)

runtimeWebService.solutions.each() do |solution|
  puts solution.name
  solution.projects.each() do |project|
    puts "   #{project.name}"
  end
  puts "\r\n"
end

runtimeWebService.toFile("Packages/runtimeWebServicePackage.yml")

puts "Done"
